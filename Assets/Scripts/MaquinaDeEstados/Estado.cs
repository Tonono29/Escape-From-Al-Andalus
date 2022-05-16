using UnityEngine;
using UnityEngine.AI;
public abstract class Estado
{
    protected MaquinaEstados maquinaEstados;
    protected NavMeshAgent agente;
    protected Estado(MaquinaEstados maquina, NavMeshAgent agentenavmesh,Vector3[] listadestinos)
    {
       this.maquinaEstados = maquina;
       this.agente = agentenavmesh;
    }
    public abstract void Entrar();
    public abstract void Salir();
}