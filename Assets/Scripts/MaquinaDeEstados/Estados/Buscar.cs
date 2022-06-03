using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Buscar : Estado
{ 
    //public bool estoyEnespera = false;
    float inicioEspera=0;
    float tiempoEspera=4;
    float tiempoTranscurrido=0;
    private bool esperacompletado=false;
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
            bool bueno =false;
            int intentos = 0;
            while (bueno == false)
            {
                target = Generardestino(zombie.transform.position);
                if (agente.CalculatePath(target, caminoNavmesh) && caminoNavmesh.status == NavMeshPathStatus.PathComplete)
                {
                    listaDestinos[i] = target;
                    bueno = true;
                }
                intentos++;
                if(intentos>100)
                {
                    Debug.Log("WARNING.He llegado al top de intentos para generar destino aleatorio");
                    listaDestinos[i] = this.zombie.transform.position;
                    bueno = true;
                }
            }
        }
        puntodestino = listaDestinos[0];
        esperacompletado = false;
        inicioEspera = 0;
        agente.SetDestination(puntodestino);
        destinoActual = 0;
    }

    public override void Salir()
    {
        agente.ResetPath();
    }
    public override void Actualizar()
    {
        if (Vector3.Distance(zombie.transform.position, puntodestino) < 1.5)
        {

            if (esperacompletado)
            {
                destinoActual++;
                if (destinoActual < 3)
                {
                    puntodestino = listaDestinos[destinoActual];
                    agente.SetDestination(puntodestino);
                    this.zombie.animacionAndar = true;
                    esperacompletado = false;
                    inicioEspera =0;
                }
                else
                {
                    maquinaEstados.CambiarEstado(zombie.patrullando);
                }
            }
            else
            {
                if (inicioEspera == 0)
                {
                    this.zombie.animacionAndar = false;
                    inicioEspera = Time.time;
                    tiempoEspera = Random.Range(2f, 5f);
                }
                if(Time.time-inicioEspera>=tiempoEspera)
                {
                    esperacompletado = true;
                }
            }
        }
        else
        {

        }
    }
    public override void JugadorEncontrado(GameObject jugador,GameObject sombie)
    {
        if (sombie == this.zombie.gameObject)
        {
            //this.zombie.animatorZombie.SetBool("Esperando", false);
            cambiarJugadorEncontrado(jugador);
            maquinaEstados.CambiarEstado(zombie.persiguiendo);
        }
    }
    private Vector3 Generardestino(Vector3 posiZombie)
    {
        Vector3 posi;
        float x;
        float z;
        x = Random.Range(1,2);
        z = Random.Range(1,2);
        posi = posiZombie + new Vector3(x,0, z);
        return posi;
    }
}
