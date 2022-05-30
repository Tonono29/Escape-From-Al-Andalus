using UnityEngine;
using UnityEngine.AI;
public abstract class Estado
{
    protected string nombreEstado;
    protected MaquinaEstados maquinaEstados;
    protected NavMeshAgent agente;
    protected Zombie zombie;
    protected static GameObject jugadorEncontrado;
   
    protected Estado(MaquinaEstados maquina, NavMeshAgent agenteNavmesh,Zombie zombie)
    {
        //Ojos.Instanciaojos.OnJugadorEncontrado +=JugadorEncontrado;
        //Ojos.Instanciaojos.OnJugadorPerdido +=JugadorPerdido;
        //mirarController.OjosController.Encontrado += Misojos;
        EscuchadorEventos.OnJugadorEncontrado += JugadorEncontrado;
        this.maquinaEstados = maquina;
        this.agente = agenteNavmesh;
        this.zombie = zombie;
    }
    public virtual void Entrar()
    {
        //Debug.Log("Ha entrado en Estado "+this);
    }
    public abstract void Salir();
    public abstract void Actualizar();
    public abstract void JugadorEncontrado(GameObject jugador);
    public abstract void Misojos(GameObject jugador);
   
    public virtual void JugadorPerdido(GameObject jugador)
    {
    }
    protected void cambiarJugadorEncontrado(GameObject jugadorEncontrado)
    {
        Estado.jugadorEncontrado = jugadorEncontrado;
        //Debug.Log("He encontrado al jugador " + Estado.jugadorEncontrado);
        if (jugadorEncontrado == null)
        {
            //Debug.Log("No se ha cambiado el jugador con exito");
        }
        else
        {
            //Debug.Log("SI se ha cambiado el jugador con exito");
        }
    }
 
}