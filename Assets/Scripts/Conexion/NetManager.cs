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
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("JoseRamon", new Vector3(105.952637f, 8.14999962f, 56.8385048f), Quaternion.identity);
            PhotonNetwork.Instantiate("Oscar", new Vector3(139.479996f, 10.7299995f, 62.5499992f), Quaternion.identity);
            PhotonNetwork.Instantiate("Elisa", new Vector3(74.0706863f, 11.1000004f, 72.6491089f), Quaternion.identity);
            PhotonNetwork.Instantiate("Maria", new Vector3(136.330002f, 6.01599979f, 54.3699989f), Quaternion.identity);
            PhotonNetwork.Instantiate("Andres", new Vector3(123.559998f, -2.38f, 85.1999969f), Quaternion.identity);
            PhotonNetwork.Instantiate("JuanAntonio", new Vector3(121.160004f, -0.469999999f, 51.4500008f), Quaternion.identity);
        }
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
