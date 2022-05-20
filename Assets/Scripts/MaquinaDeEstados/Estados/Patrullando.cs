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
        base.Entrar();
        int destinoAleatorio;
        totalpuntosdestino = this.destinosPatrulla.Length;
        destinoAleatorio = Random.Range(0, totalpuntosdestino);
        destinoActual = destinosPatrulla[destinoAleatorio];
        this.agente.ResetPath();
        Debug.Log("Mi destino actual es :" + destinoActual);
        this.agente.SetDestination(destinoActual);
    }
    public override void Salir()
    {
        this.agente.ResetPath();
    }
    public override void Actualizar()
    {
        //Debug.Log(zombie.transform.position);
        if(Vector3.Distance(zombie.transform.position,destinoActual)<1)
        {
            maquinaEstados.CambiarEstado(zombie.buscando);
        }
    }
    public override void JugadorEncontrado(GameObject jugador)
    {    
        maquinaEstados.CambiarEstado(zombie.persiguiendo);
        cambiarJugadorEncontrado(jugador);
    }
}
