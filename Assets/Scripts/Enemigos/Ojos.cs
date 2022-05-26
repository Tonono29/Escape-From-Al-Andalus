using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour
{
    #region Delegados
    public delegate void ManejadorJugadorPerdido(GameObject jugador);
    public delegate void ManejadorJugadorEncontrado(GameObject jugador);
    #endregion
    #region Eventos
    public event ManejadorJugadorPerdido OnJugadorPerdido;
    public event ManejadorJugadorEncontrado OnJugadorEncontrado;
    #endregion
    public static Ojos Instanciaojos { get; private set;}
    private void Awake()
    {
        if (Instanciaojos!=null)
        {
            Destroy(gameObject);
        }
        Instanciaojos = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Jugador")
        {
            OnJugadorEncontrado.Invoke(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Jugador")
        {
            OnJugadorPerdido?.Invoke(other.gameObject);
        }
    }
}
