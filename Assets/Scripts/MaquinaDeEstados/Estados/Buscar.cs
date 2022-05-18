using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Buscar : Estado
{
    private int destinoActual = 0;
    private Vector3 puntodestino;
    private NavMeshPath caminoNavmesh=new NavMeshPath();
    private Vector3[] listaDestinos;
    public Buscar(MaquinaEstados maquina, NavMeshAgent agente, Zombie zombie) : base(maquina, agente, zombie)
    {
    }
    public override void Entrar()
    {
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
        if(zombie.transform.position==puntodestino)
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
        Perseguir perseguir = new Perseguir(maquinaEstados, agente, zombie, jugador);
        maquinaEstados.CambiarEstado(perseguir);
    }
    private Vector3 Generardestino(Vector3 posiZombie)
    {
        Vector3 posi;
        float x;
        float z;
        x = Random.Range(0,3);
        z = Random.Range(0,3);
        posi = posiZombie + new Vector3(x, 0, z);
        return posi;
    }
}
