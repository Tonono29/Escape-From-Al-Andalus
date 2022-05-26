using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetManager : MonoBehaviour
{
    public GameObject spaw1;
    public GameObject spaw2;

    // Start is called before the first frame update
    void Start()
    {
        int numJugador = PhotonNetwork.LocalPlayer.ActorNumber;

        if (numJugador == 1)
        {
            PhotonNetwork.Instantiate("Jugador01", spaw1.transform.position, Quaternion.identity);
        }
        else if (numJugador == 2)
        {
            PhotonNetwork.Instantiate("Jugador02", spaw2.transform.position, Quaternion.identity);
        }
    }    
}
