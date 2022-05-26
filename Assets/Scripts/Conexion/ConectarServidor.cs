using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConectarServidor : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject personaje01;
    [SerializeField] private GameObject personaje02;
    [SerializeField] private GameObject personaje03;
    [SerializeField] private GameObject personaje04;
    private int personajeActivo = 1;

    public InputField nickname;
    public Text textoBoton;
    public Button boton;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void cambiarPersonaje()
    {
        switch (personajeActivo)
        {
            case 1:
                personaje01.SetActive(false);
                personaje02.SetActive(true);
                personaje03.SetActive(false);
                personaje04.SetActive(false);
                personajeActivo = 2;
                break;
            case 2:
                personaje01.SetActive(false);
                personaje02.SetActive(false);
                personaje03.SetActive(true);
                personaje04.SetActive(false);
                personajeActivo = 3;
                break;
            case 3:
                personaje01.SetActive(false);
                personaje02.SetActive(false);
                personaje03.SetActive(false);
                personaje04.SetActive(true);
                personajeActivo = 4;
                break;
            case 4:
                personaje01.SetActive(true);
                personaje02.SetActive(false);
                personaje03.SetActive(false);
                personaje04.SetActive(false);
                personajeActivo = 1;
                break;
            default:
                break;
        }
    }

    public void pulsarConectar()
    {
        boton.enabled = false;
        textoBoton.text = "Conectando...";

        if(nickname.text.Length >=1)
        {
            PhotonNetwork.NickName = nickname.text;
            PhotonNetwork.ConnectUsingSettings();

        }
    }

    public void pulsarSalir()
    {
        boton.enabled = false;
        SceneManager.LoadScene("menu");
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("lobby");
    }

}
