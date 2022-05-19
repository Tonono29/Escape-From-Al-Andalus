using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojos : MonoBehaviour
{
    [SerializeField] private float vision;
    private float centroVision;
    private BoxCollider visionCollider;
    #region Delegados
    public delegate void ManejadorJugadorPerdido(GameObject jugador);
    public delegate void ManejadorJugadorEncontrado(GameObject jugador);
    #endregion
    #region Eventos
    public event ManejadorJugadorPerdido OnJugadorPerdido;
    public event ManejadorJugadorEncontrado OnJugadorEncontrado;
    #endregion
    public static Ojos Instancia { get; private set;}
    private void Awake()
    {
        //centroVision = (vision / 2);
        //visionCollider = GetComponent<BoxCollider>();
        //visionCollider.size =new Vector3(visionCollider.size.x,visionCollider.size.y,vision);
        //visionCollider.center = new Vector3(visionCollider.center.x, visionCollider.center.y, (vision));
        if (Instancia!=null)
        {
            Destroy(gameObject);
        }
        Instancia = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Jugador")
        {
            OnJugadorEncontrado?.Invoke(other.gameObject);
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
