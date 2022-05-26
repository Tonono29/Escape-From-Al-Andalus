using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionPuerta : MonoBehaviour
{
    [SerializeField]private GameObject objetoPivote;
    public bool puertaAbierta=false;
    private void Start()
    {
        PlayerController.Instancia.OnAbrirCerrar += AbrirCerrar;
    }
    public void AbrirPuerta()
    {
        this.transform.RotateAround(objetoPivote.transform.position,Vector3.up,120);
    }
    public void CerrarPuerta()
    {
        this.transform.RotateAround(objetoPivote.transform.position, Vector3.up*-1, 120);
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
        puertaAbierta =!puertaAbierta;
    }
}
