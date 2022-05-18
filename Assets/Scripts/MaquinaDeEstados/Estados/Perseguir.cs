using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : Estado
{
    private GameObject jugadorobjetivo;
    private Vector3 posicionjugador;
    public Perseguir(MaquinaEstados maquina, NavMeshAgent agente, Zombie zombie, GameObject jugador) : base(maquina, agente, zombie)
    {
        jugadorobjetivo = jugador;
    }
    public override void Entrar()
    {
        agente.ResetPath();  
    }

    public override void Salir()
    {
        agente.ResetPath();
    }
    public override void Actualizar()
    {
        posicionjugador = jugadorobjetivo.transform.position;
        agente.SetDestination(posicionjugador);
    }
    public override void JugadorEncontrado(GameObject jugador)
    {
        if (jugador==jugadorobjetivo)
        {
            jugadorobjetivo = jugador;
        }
    }
    public override void JugadorPerdido(GameObject jugador)
    {
        if (jugador==jugadorobjetivo)
        {
            Debug.Log("Me voy a buscar");
            Buscar buscar = new Buscar(maquinaEstados, agente, zombie);
            maquinaEstados.CambiarEstado(buscar);
        }
    }
}
