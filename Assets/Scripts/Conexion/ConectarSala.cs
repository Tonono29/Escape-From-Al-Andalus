using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConectarSala : MonoBehaviourPunCallbacks
{
    public Text titulo;
    public Button boton_sala1;
    public Button boton_sala2;
    public Button boton_sala3;
    public Button boton_sala4;
    public Button boton_sala5;
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    public void Start()
    {
        //titulo.text = "Bienvenido " + PhotonNetwork.NickName;
    }

    public void pulsa_botonS1()
    {
        boton_sala1.enabled = false;
        boton_sala2.enabled = false;
        boton_sala3.enabled = false;
        boton_sala4.enabled = false;
        boton_sala5.enabled = false;
        source.PlayOneShot(clip);
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("Server1", opciones, TypedLobby.Default);
    }

    public void pulsa_botonS2()
    {
        boton_sala1.enabled = false;
        boton_sala2.enabled = false;
        boton_sala3.enabled = false;
        boton_sala4.enabled = false;
        boton_sala5.enabled = false;
        source.PlayOneShot(clip);
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server2", opciones, TypedLobby.Default);
    }

    public void pulsa_botonS3()
    {
        boton_sala1.enabled = false;
        boton_sala2.enabled = false;
        boton_sala3.enabled = false;
        boton_sala4.enabled = false;
        boton_sala5.enabled = false;
        source.PlayOneShot(clip);
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server3", opciones, TypedLobby.Default);
    }
    public void pulsa_botonS4()
    {
        boton_sala1.enabled = false;
        boton_sala2.enabled = false;
        boton_sala3.enabled = false;
        boton_sala4.enabled = false;
        boton_sala5.enabled = false;
        source.PlayOneShot(clip);
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server4", opciones, TypedLobby.Default);
    }
    public void pulsa_botonS5()
    {
        boton_sala1.enabled = false;
        boton_sala2.enabled = false;
        boton_sala3.enabled = false;
        boton_sala4.enabled = false;
        boton_sala5.enabled = false;
        source.PlayOneShot(clip);
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server5", opciones, TypedLobby.Default);
    }

    public void pulsaSalir()
    {
        boton_sala1.enabled = false;
        boton_sala2.enabled = false;
        boton_sala3.enabled = false;
        boton_sala4.enabled = false;
        boton_sala5.enabled = false;
        source.PlayOneShot(clip);
        StartCoroutine("salirJuego");
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            int jugadoresC = PhotonNetwork.CurrentRoom.PlayerCount;

            titulo.text = "Esperando jugadores..." + jugadoresC + "/2";

            if (PhotonNetwork.IsMasterClient && jugadoresC == 2)
            {
                string salaNombre = PhotonNetwork.CurrentRoom.Name;

                if (salaNombre == "Server1")
                {
                    PhotonNetwork.LoadLevel("Escenamu");
                }
                else if (salaNombre == "Server2")
                {
                    PhotonNetwork.LoadLevel("Server2");
                }
                else if (salaNombre == "Server3")
                {
                    PhotonNetwork.LoadLevel("Server3");
                }
                else if (salaNombre == "Server4")
                {
                    PhotonNetwork.LoadLevel("Server4");
                }
                else if (salaNombre == "Server5")
                {
                    PhotonNetwork.LoadLevel("Server5");
                }
                Destroy(this);
            }
        }
    }
    IEnumerator salirJuego()
    {
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("menu");
        PhotonNetwork.Disconnect();
    }
}
