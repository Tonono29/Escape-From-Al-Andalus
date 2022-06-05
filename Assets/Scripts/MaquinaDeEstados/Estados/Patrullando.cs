using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullando : Estado
{
    private int totalpuntosdestino;
    private Vector3[] destinosPatrulla;
    private Vector3 destinoActual;
    public Patrullando(MaquinaEstados maquina,NavMeshAgent agente,Zombie zombie, Vector3[] destinos) : base(maquina, agente,zombie)
    {
        this.destinosPatrulla = destinos;
    }
    public override void Entrar()
    {
        Vector3 vectorAux;
        int destinoAleatorio;
        totalpuntosdestino = this.destinosPatrulla.Length;
        destinoAleatorio = Random.Range(0, totalpuntosdestino-1);
        destinoActual = destinosPatrulla[destinoAleatorio];
        vectorAux = destinoActual;
        destinosPatrulla[destinoAleatorio] = destinosPatrulla[totalpuntosdestino - 1];
        destinosPatrulla[totalpuntosdestino - 1] = vectorAux;
        this.agente.ResetPath();
        this.agente.SetDestination(destinoActual);
    }
    public override void Salir()
    {
        this.agente.ResetPath();
    }
    public override void Actualizar()
    {
        if(Vector3.Distance(zombie.transform.position,destinoActual)<1)
        {
            maquinaEstados.CambiarEstado(zombie.buscando);
        }
    }
    /*public override void JugadorEncontrado(GameObject jugador, GameObject sombie)
    {
        if (sombie == this.zombie.gameObject)
        {
            cambiarJugadorEncontrado(jugador);
            maquinaEstados.CambiarEstado(zombie.persiguiendo);
        }
    }*/
}
