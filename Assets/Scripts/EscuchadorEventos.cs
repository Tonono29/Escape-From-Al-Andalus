using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  static class EscuchadorEventos 
{
    #region Delegados
    //public delegate void ManejadorJugadorPerdido(GameObject jugador);
    public delegate void ManejadorJugadorEncontrado(GameObject jugador,GameObject sombi);
    public delegate void ManejadorLlave();
    //public delegate void ManejadorAbrirCerrar(GameObject puerta);
    #endregion
    #region Eventos
    //public static event ManejadorJugadorPerdido OnJugadorPerdido;
    public static event ManejadorJugadorEncontrado OnJugadorEncontrado;
    public static event ManejadorLlave OnllavePillada;
    //public static event ManejadorAbrirCerrar OnAbrirCerrarPuerta;
    #endregion 
    public static void JugadorEncontrado(GameObject juga, GameObject sombie)
    {
        OnJugadorEncontrado?.Invoke(juga,sombie);
    }
    public static void LlavePillada()
    {
        OnllavePillada?.Invoke();
    }

}
