using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : Estado
{
    private Vector3 posicionjugador;
    public Perseguir(MaquinaEstados maquina, NavMeshAgent agente, Zombie zombie) : base(maquina, agente, zombie)
    {
    }
    public override void Entrar()
    {
        if (jugadorEncontrado==null)
        {
            Debug.Log("Acabo de entrar y el maldito jugador de los huevos es nulo");
        }
        base.Entrar();
    }

    public override void Salir()
    {
        agente.ResetPath();
    }
    public override void Actualizar()
    {
        if (jugadorEncontrado == null)
        {
            Debug.Log("No puedo perseguir el jugador es nulo");
        }
        else
        {
            agente.SetDestination(jugadorEncontrado.transform.position);
        }
    }
    public override void JugadorEncontrado(GameObject jugador)
    {
    }
    public override void JugadorPerdido(GameObject jugador)
    {
        //cambiarJugadorEncontrado(null);
        maquinaEstados.CambiarEstado(zombie.buscando);
    }
}
