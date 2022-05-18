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
        int destinoAleatorio;
        base.Entrar();
        totalpuntosdestino = this.destinosPatrulla.Length;
        destinoAleatorio = Random.Range(0, totalpuntosdestino);
        destinoActual = destinosPatrulla[destinoAleatorio];
        this.agente.ResetPath();
        this.agente.SetDestination(destinoActual);
    }
    public override void Salir()
    {
        this.agente.ResetPath();
    }
    public override void Actualizar()
    {
        Debug.Log(zombie.transform.position);
        if(zombie.transform.position==destinoActual)
        {
            Buscar buscar = new Buscar(maquinaEstados, agente, zombie);
            maquinaEstados.CambiarEstado(buscar);
        }
    }
    public override void JugadorEncontrado(GameObject jugador)
    {
        Perseguir perseguir = new Perseguir(maquinaEstados, agente, zombie, jugador);
        maquinaEstados.CambiarEstado(perseguir);
    }
}
