using UnityEngine;
using UnityEngine.AI;
public abstract class Estado
{
    private Estado estadoActual;
    protected MaquinaEstados maquinaEstados;
    protected NavMeshAgent agente;
    protected Zombie zombie;
    protected Estado(MaquinaEstados maquina, NavMeshAgent agenteNavmesh,Zombie zombie)
    {
        this.maquinaEstados = maquina;
        this.agente = agenteNavmesh;
        this.zombie = zombie;
        Ojos.Instancia.OnJugadorEncontrado += JugadorEncontrado;
        Ojos.Instancia.OnJugadorPerdido += JugadorPerdido;
    }
    public virtual void Entrar()
    {
        Debug.Log("Ha entrado en Estado "+estadoActual);
    }
    public abstract void Salir();
    public void CambiarEstado(Estado nuevoEstado)
    {
        estadoActual.Salir();
        estadoActual = nuevoEstado;
        nuevoEstado.Entrar();
    }
    public abstract void Actualizar();
    public virtual void JugadorEncontrado(GameObject jugador)
    {
    }
    public virtual void JugadorPerdido(GameObject jugador)
    {
    }
}