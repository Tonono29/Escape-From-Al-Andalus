using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionPuerta : MonoBehaviour
{
    [SerializeField] Text textoui;
    [SerializeField]private GameObject objetoPivote;
    [SerializeField] private GameObject puerta;
    public bool puertaAbierta=false;
    private bool encontacto = false;
    private void Start()
    {
        //EscuchadorEventos.OnAbrirCerrarPuerta+= AbrirCerrar;
    }
    public void AbrirPuerta()
    {
        puerta.gameObject.transform.RotateAround(objetoPivote.transform.position,Vector3.up,120);
        GetComponent<AudioSource>().Play();
    }
    public void CerrarPuerta()
    {
        puerta.gameObject.transform.RotateAround(objetoPivote.transform.position, Vector3.up*-1, 120);
        GetComponent<AudioSource>().Play();
    }
    public void AbrirCerrar()
    {
        if (puertaAbierta)
        {
            CerrarPuerta();
        }
        else
        {
            AbrirPuerta();
        }
        puertaAbierta = !puertaAbierta;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            encontacto = true;
            if (puertaAbierta)
            {
                textoui.text = "Pulsa E para cerrar la puerta";
            }
            else
            {
                textoui.text = "Pulsa E para abrir la puerta";
            }
        }
        else
        {
            encontacto = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        encontacto = false;
        textoui.text = "";
    }
    public void OnInteraccion()
    {
        if (encontacto)
        {
            AbrirCerrar();
        }

    }
}
