using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullando : Estado
{

    protected Patrullando(MaquinaEstados maquina,NavMeshAgent agente, Vector3[] destinos,Zombie zombie) : base(maquina, agente,destinos,zombie)
    {
    }
    public override void Entrar()
    {
        int totalpuntosdestino;
        
    }
    public override void Salir()
    {
        this.agente.ResetPath();
    }
    IEnumerator patrullar(Vector3 destinopatrulla)
    {
        this.agente.ResetPath();
        this.agente.SetDestination(destinopatrulla);
        while (this.zombie.transform.position!=destinopatrulla)
        {
            yield return new WaitForSeconds(1);
        }
    }
}
