using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Buscar : Estado
{
    public bool estoyEnespera = false;
    private int destinoActual = 0;
    private Vector3 puntodestino;
    private NavMeshPath caminoNavmesh=new NavMeshPath();
    private Vector3[] listaDestinos;
    public Buscar(MaquinaEstados maquina, NavMeshAgent agente, Zombie zombie) : base(maquina, agente, zombie)
    {
        //this.nombreEstado = "Buscar";
    }
    public override void Entrar()
    {
        base.Entrar();
        Vector3 target;
        listaDestinos = new Vector3[3];
        for (int i = 0; i < 3; i++)
        {
            bool bueno = false;
            while (bueno == false)
            {
                target = Generardestino(zombie.transform.position);
                if (agente.CalculatePath(target, caminoNavmesh) && caminoNavmesh.status == NavMeshPathStatus.PathComplete)
                {
                    listaDestinos[i] = target;
                    bueno = true;
                }
            }
        }
        puntodestino = listaDestinos[0];
        agente.SetDestination(puntodestino);
        destinoActual = 0;
    }

    public override void Salir()
    {
        agente.ResetPath();
    }
    public override void Actualizar()
    {
        if (Vector3.Distance(zombie.transform.position, puntodestino) < 1)
        {
            destinoActual++;
            if (destinoActual < 3)
            {
                puntodestino = listaDestinos[destinoActual];
                agente.SetDestination(puntodestino);
            }
            else
            {
                maquinaEstados.CambiarEstado(zombie.patrullando);
            }
        }
    }
    public override void JugadorEncontrado(GameObject jugador)
    {
        Debug.Log("jugador encontrado desde buscar");
        cambiarJugadorEncontrado(jugador);
        maquinaEstados.CambiarEstado(zombie.persiguiendo);
    }
    public override void Misojos(GameObject jugador)
    {
        Debug.Log("jugador encontrado desde buscar");
        cambiarJugadorEncontrado(jugador);
        maquinaEstados.CambiarEstado(zombie.persiguiendo);
    }
    private Vector3 Generardestino(Vector3 posiZombie)
    {
        Vector3 posi;
        float x;
        float z;
        x = Random.Range(0,3);
        z = Random.Range(0,3);
        posi = posiZombie + new Vector3(x,0, z);
        return posi;
    }
}
