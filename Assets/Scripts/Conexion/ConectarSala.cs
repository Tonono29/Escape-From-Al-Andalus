using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ConectarSala : MonoBehaviourPunCallbacks
{
    public Text titulo;
    public Button boton_sala1;
    public Button boton_sala2;

    // Start is called before the first frame update
    void Start()
    {
        titulo.text = "Bienvenido " + PhotonNetwork.NickName;
    }

    public void pulsa_botonS1()
    {
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server1", opciones, TypedLobby.Default);
    }

    public void pulsa_botonS2()
    {
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server2", opciones, TypedLobby.Default);
    }
    public void pulsa_botonS3()
    {
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server3", opciones, TypedLobby.Default);
    }

    public void pulsa_botonS4()
    {
        RoomOptions opciones = new RoomOptions();
        opciones.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("Server4", opciones, TypedLobby.Default);
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            int jugadoresC = PhotonNetwork.CurrentRoom.PlayerCount;

            titulo.text = "Esperando jugadores..." + jugadoresC + "/4";

            if (PhotonNetwork.IsMasterClient && jugadoresC == 4)
            {
                string salaNombre = PhotonNetwork.CurrentRoom.Name;

                if (salaNombre == "Server1")
                {
                    PhotonNetwork.LoadLevel("Server1");
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

                Destroy(this);
            }
        }
    }
}
