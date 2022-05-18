using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agenteNav;
    [SerializeField] private Vector3[] destinos;
    public MaquinaEstados maquinaEstados;
    public Patrullando patrullando;
    public Buscar buscando;
    //public Perseguir perseguir;

    private void Start()
    {
        maquinaEstados = new MaquinaEstados();
        patrullando = new Patrullando(maquinaEstados, agenteNav, this,destinos);
        maquinaEstados.Inicializar(patrullando);
    }
    private void Update()
    {
        maquinaEstados.EstadoActual.Actualizar();
    }
}
