using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Llave : MonoBehaviour
{
    [SerializeField] private Text textoui;
    // Start is called before the first frame update
    private void Awake()
    {
        EscuchadorEventos.OnllavePillada += LlavePillada;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            textoui.text = "Pulsa E para coger la llave y abrir la puerta doble";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        textoui.text = "";
    }
    private void LlavePillada()
    {
        GetComponent<AudioSource>().Play();
        textoui.text = "";
        Destroy(this.transform.parent.gameObject);
    }
}
