using UnityEngine;
using Photon.Pun;
using Photon.Voice.PUN;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControllerJose : MonoBehaviour
{
    [SerializeField] Text textoui;
    [SerializeField] private Camera miCamara;
    CharacterController characterController;
    public float MovementSpeed =1;
    public float Gravity = 9.8f;
    private float velocity = 0;
    RaycastHit miRayito;
    public static PlayerControllerJose Instancia { get; private set; }
    private void Awake()
    {
        chat = GetComponent<PhotonVoiceView>();
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
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }   
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(miCamara.transform.position, miCamara.transform.forward, out miRayito, 5))
        {
            if (miRayito.transform.gameObject.tag == "Puerta")
            {
                //OnInteraccionPuerta?.Invoke(miRayito.transform.gameObject.GetComponent<InteraccionPuerta>().puertaAbierta);
                miRayito.transform.gameObject.GetComponent<InteraccionPuerta>().MostrarUiPuertas();
            }
            else
            {
                textoui.text = "";
            }
            Debug.DrawRay(miCamara.transform.position, miCamara.transform.forward, Color.yellow);
        }

    }
    public void OnInteraccion()
    {
        if (Physics.Raycast(miCamara.transform.position, miCamara.transform.forward, out miRayito, 5))
        {
            if (miRayito.transform.gameObject.tag == "Puerta")
            {
                OnAbrirCerrar?.Invoke();
            }
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
}
