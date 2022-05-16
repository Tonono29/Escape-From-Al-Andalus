using UnityEngine;
using UnityEngine.AI;
public abstract class Estado
{
    protected MaquinaEstados maquinaEstados;
    protected NavMeshAgent agente;
    protected Zombie zombie;
    protected Estado(MaquinaEstados maquina, NavMeshAgent agentenavmesh,Vector3[] listadestinos,Zombie zombie)
    {
       this.maquinaEstados = maquina;
       this.agente = agentenavmesh;
    }
    public abstract void Entrar();
    public abstract void Salir();
}