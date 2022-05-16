using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullando : Estado
{
    private Vector3 listadestinos;
    protected Patrullando(NavMeshAgent agente, Vector3 destinos)
    {
        this.agente = base.agente;
        this.listadestinos = destinos;
    }

    public override void Entrar()
    {
        
    }
    public override void Salir()
    {

    }
}
