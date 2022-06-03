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
        this.zombie.animacionAndar = true;
        if (jugadorEncontrado==null)
        {
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
        }
        else
        {
            agente.SetDestination(jugadorEncontrado.transform.position);
        }
    }
    public override void JugadorEncontrado(GameObject jugador,GameObject sombi)
    {
    }
    public override void JugadorPerdido(GameObject jugador)
    {
        maquinaEstados.CambiarEstado(zombie.buscando);
    }
}
