using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaLllave : MonoBehaviour
{
    [SerializeField] Text textoui;
    [SerializeField] private GameObject objetoPivote1;
    [SerializeField] private GameObject puerta1;
    [SerializeField] private GameObject objetoPivote;
    [SerializeField] private GameObject puerta;
    private bool tieneLlave = false;
    public bool puertaAbierta = false;
    private bool encontacto = false;
    private void Start()
    {
        //EscuchadorEventos.OnAbrirCerrarPuerta+= AbrirCerrar;
    }
    public void AbrirPuerta()
    {
        puerta1.gameObject.transform.RotateAround(objetoPivote1.transform.position, Vector3.up, 120);
        puerta.gameObject.transform.RotateAround(objetoPivote.transform.position, Vector3.up, -120);
    }
    public void CerrarPuerta()
    {
        puerta1.gameObject.transform.RotateAround(objetoPivote1.transform.position, Vector3.up * -1, 120);
        puerta.gameObject.transform.RotateAround(objetoPivote.transform.position, Vector3.up * 1, 120);
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
            if (other.gameObject.GetComponent<PlayerControllerTonono>().tengoLlave)
            {
                textoui.text="YA TIENES LA LLAVE, pulsa E para abrir las puertas";
                tieneLlave = true;
            }
            else
            {
                textoui.text = "No tienes la llave para salir, normalmente la suele tele la profesora que merodea esta planta";
                tieneLlave = false;
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
        if ((encontacto)&&(tieneLlave))
        {
            AbrirCerrar();
        }

    }
}
