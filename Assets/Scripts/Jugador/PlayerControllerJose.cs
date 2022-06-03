using UnityEngine;
using Photon.Pun;
using Photon.Voice.PUN;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControllerJose : MonoBehaviour
{
    CharacterController characterController;
    public float MovementSpeed = 1;
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
