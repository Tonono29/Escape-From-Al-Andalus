using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager:MonoBehaviour
{
    [SerializeField] private Text textoUi;
   /* private void Start()
    {
        PlayerController.Instancia.OnInteraccionPuerta += InteractuarPuerta;
        PlayerController.Instancia.OnLimpiar += LimpiarUI;
    }*/

    /*public void InteractuarPuerta(bool estadoPuerta)
    {
        if (estadoPuerta)
        {
            textoUi.text = "Pulsa E para cerrar la puerta";
        }
        else
        {
            textoUi.text = "Pulsa E para abrir la puerta";
        }
    }
    public void LimpiarUI()
    {
        textoUi.text = "";
    }
    */
    //public void CambiarTextoUi(string texto)
    //{
       // textoUi.text = texto;
    //}
}
