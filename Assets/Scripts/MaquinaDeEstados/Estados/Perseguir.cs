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
        }
        base.Entrar();
        Debug.Log("Estoy persiguien");
    }

    public override void Salir()
    {
        agente.ResetPath();
    }
    public override void Actualizar()
    {
        Debug.Log("Mi posicion objetivo es "+jugadorEncontrado.transform.position);
        if (jugadorEncontrado == null)
        {
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
        maquinaEstados.CambiarEstado(zombie.buscando);
    }
    public override void Misojos(GameObject jugador)
    {
    }
}
