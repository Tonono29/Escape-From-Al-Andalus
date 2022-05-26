using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] private Text textoUi;
    private void Start()
    {
        PlayerController.Instancia.OnInteraccionPuerta += InteractuarPuerta;
    }

    private void Update()
    {   
    }
    public void InteractuarPuerta(bool estadoPuerta)
    {
        //Debug.Log("Estoy entrando al evento subscrito");
        if (estadoPuerta)
        {
            textoUi.text = "Pulsa E para cerrar la puerta";
        }
        else
        {
            textoUi.text = "Pulsa E para abrir la puerta";
        }
    }
}
