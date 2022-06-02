using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice;
using Photon.Voice.PUN;
using Photon.Voice.Unity;

public class NetManager : MonoBehaviour
{
    public GameObject spaw1;
    public GameObject spaw2;
    private PhotonVoiceNetwork chat;
    private Recorder rec;

    // Start is called before the first frame update
    void Start()
    {
        int numJugador = PhotonNetwork.LocalPlayer.ActorNumber;

        if (numJugador == 1)
        {
            PhotonNetwork.Instantiate("Jugador0"+ ConectarServidor.personajeActivo, spaw1.transform.position, Quaternion.identity);
        }
        else if (numJugador == 2)
        {
            PhotonNetwork.Instantiate("Jugador0" + ConectarServidor.personajeActivo, spaw2.transform.position, Quaternion.identity);
        }
        /*
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("zombi", new Vector3(15, 0, 15), Quaternion.identity);
        }
        */
        //StartCoroutine("conectarChat");
    }
    private IEnumerator conectarChat()
    {
        while (chat.ClientState != Photon.Realtime.ClientState.Joined)
        {
            yield return new WaitForEndOfFrame();
        }

        int numJugador = PhotonNetwork.LocalPlayer.ActorNumber;

        switch (numJugador)
        {
            case 1:
                chat.Client.OpChangeGroups(null, new byte[1] { 1 });
                rec.InterestGroup = 1;
                break;
            case 2:
                chat.Client.OpChangeGroups(null, new byte[1] { 1 });
                rec.InterestGroup = 1;
                break;
            case 3:
                chat.Client.OpChangeGroups(null, new byte[1] { 2 });
                rec.InterestGroup = 2;
                break;
            case 4:
                chat.Client.OpChangeGroups(null, new byte[1] { 2 });
                rec.InterestGroup = 2;
                break;
        }
    }
}
