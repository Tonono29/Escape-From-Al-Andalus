using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionPuerta : MonoBehaviour
{
    [SerializeField] Text textoui;
    [SerializeField]private GameObject objetoPivote;
    public bool puertaAbierta=false;
    private void Start()
    {
        EscuchadorEventos.OnAbrirCerrarPuerta+= AbrirCerrar;
    }
    public void AbrirPuerta()
    {
        this.transform.RotateAround(objetoPivote.transform.position,Vector3.up,120);
    }
    public void CerrarPuerta()
    {
        this.transform.RotateAround(objetoPivote.transform.position, Vector3.up*-1, 120);
    }
    public void AbrirCerrar(GameObject puerta)
    {
        if (this.gameObject == puerta)
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
    }
    public void MostrarUiPuertas()
    {
        if (puertaAbierta)
        {
            textoui.text="Pulsa E para cerrar la puerta";
        }
        else
        {
            textoui.text = "Pulsa E para abrir la puerta";
        }
    }
}
