using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : Estado
{
    private Vector3 posicionjugador;
    public GameObject jugadorEncontrado;
    private Vector3 destinoCorregido;
    public Perseguir(MaquinaEstados maquina, NavMeshAgent agente, Zombie zombie) : base(maquina, agente, zombie)
    {
    }
    public override void Entrar()
    {
        Debug.Log("He entrado en perseguir y soy zombie "+zombie);
    }

    public override void Salir()
    {
        Debug.Log("voy a salir de peresguir reseteo");
        agente.ResetPath();
    }
    public override void Actualizar()
    {
        if (jugadorEncontrado == null)
        {
            Debug.Log("EL jugador esta nulo");
        }
        else
        {
            //agente.ResetPath();
            destinoCorregido = jugadorEncontrado.transform.position + new Vector3(0, this.zombie.factorCorreccionAltura, 0);
            agente.SetDestination(destinoCorregido);
        }
    }
    /*public override void JugadorEncontrado(GameObject jugador,GameObject sombi)
    {
    }
    public override void JugadorPerdido(GameObject jugador)
    {
        maquinaEstados.CambiarEstado(zombie.buscando);
    }*/
}
