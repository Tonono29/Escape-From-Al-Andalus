using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConectarServidor : MonoBehaviourPunCallbacks
{
    public InputField nickname;
    public Text textoBoton;
    public Button boton;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void pulsarBoton()
    {
        boton.enabled = false;
        textoBoton.text = "Conectando...";

        if(nickname.text.Length >=1)
        {
            PhotonNetwork.NickName = nickname.text;
            PhotonNetwork.ConnectUsingSettings();

        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("lobby");
    }

}
