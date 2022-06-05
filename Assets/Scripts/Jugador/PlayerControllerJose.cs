using UnityEngine;
using Photon.Pun;
using Photon.Voice.PUN;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerJose : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;
    RaycastHit miRayito;
    public bool tengoLlave = false;
    private bool contactoConLlave = false;
    private Text textoui;
    public static PlayerControllerJose Instancia { get; private set; }
    private void Awake()
    {
        textoui =GameObject.Find("UI").GetComponentInChildren<Text>();
        //chat = GetComponent<PhotonVoiceView>();
        //habla = transform.GetChild(1).transform.gameObject;
    }
    public TextMesh nick;
    private GameObject habla;

    private PhotonView pw;
    private PhotonVoiceView chat;
    private void Start()
    {
        pw = GetComponent<PhotonView>();
        if (pw.IsMine)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        if (pw.IsMine)
        {
            pw.RPC("nombreUsuario", RpcTarget.All, PhotonNetwork.NickName);
            //movimiento
            float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
            float vertical = Input.GetAxis("Vertical") * MovementSpeed;
            characterController.Move((transform.right * horizontal + transform.forward * vertical) * Time.deltaTime);

            // gravedad
            if (characterController.isGrounded)
            {
                velocity = 0;
            }
            else
            {
                velocity -= Gravity * Time.deltaTime;
                characterController.Move(new Vector3(0, velocity, 0));
            }
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            chat.RecorderInUse.TransmitEnabled = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            chat.RecorderInUse.TransmitEnabled = false;
        }
        if (chat.IsRecording)
        {
            pw.RPC("estaHablando", RpcTarget.All, true);
        }
        else
        {
            pw.RPC("estaHablando", RpcTarget.All, false);
        }
        */
    }
    IEnumerator desconectar()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }
        SceneManager.LoadScene("lobby");
        Destroy(this.gameObject);
    }
    [PunRPC]
    void nombreUsuario(string usuario)
    {
        nick.text = usuario;
    }
    [PunRPC]
    void estaHablando(bool h)
    {
        habla.SetActive(h);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PuertaLlave")
        {
            if (tengoLlave == false)
            {
                textoui.text = "Para poder pasar necesitas una llave, normalmente la profesora que esta en esta planta la suele llevar encima";
            }
            else
            {
                textoui.text = "Ya tienes la llave pulsa E para abrir la puerta";
            }
        }
        else
        {
            textoui.text = "";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            hasPerdido();
        }
    }
    private void hasPerdido()
    {
        Camera miCamara = Camera.main;
        miCamara.transform.SetParent(transform.parent);
        Destroy(this.gameObject);
        miCamara.transform.position += new Vector3(-5, 5, 0);
        miCamara.transform.Rotate(50, 0, 0);
        textoui.text = "HAS PERDIDO TE HA PILLADO UN SOMBIII";
    }
    private void OnTriggerExit(Collider other)
    {
        contactoConLlave = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Llave")
        {
            contactoConLlave = true;
        }
    }
    public void OnInteraccion()
    {
        if ((contactoConLlave) && (tengoLlave == false))
        {
            tengoLlave = true;
            EscuchadorEventos.LlavePillada();
        }
    }
}
