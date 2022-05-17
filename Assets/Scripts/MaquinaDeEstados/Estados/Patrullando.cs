using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullando : Estado
{
    //private GameObject zombiepatrulla;
    private int totalpuntosdestino;
    private Vector3[] destinosPatrulla;
    private Vector3 destinoActual;
    private Zombie zombiepatrulla;
    private MaquinaEstados mimaquinadeestados;
    public Patrullando(MaquinaEstados maquina,NavMeshAgent agente,Zombie zombie, Vector3[] destinos) : base(maquina, agente,zombie)
    {
        this.destinosPatrulla = destinos;
        this.zombiepatrulla = zombie;
        this.mimaquinadeestados = maquina;
    }
    public override void Entrar()
    {
        int destinoAleatorio;
        Debug.Log("He entrado en patrullando");
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
        Debug.Log("Saliendo de patrullando");
    }
    public override void Actualizar()
    {
        if(this.zombiepatrulla.transform.position==destinoActual)
        {
            Debug.Log("He llegado al destino");
            mimaquinadeestados.CambiarEstado(zombie.patrullando);
        }
    }
    public override void JugadorEncontrado(GameObject jugador)
    {
        Debug.Log("jugador Encontrado");
    }
}
