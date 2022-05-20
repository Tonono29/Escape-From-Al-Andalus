using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agenteNav;
    [SerializeField] public Vector3[] destinos;
    public MaquinaEstados maquinaEstados;
    public Patrullando patrullando;
    public Buscar buscando;
    public Perseguir persiguiendo;
    //public Perseguir perseguir;

    private void Start()
    {
        maquinaEstados = new MaquinaEstados();
        patrullando = new Patrullando(maquinaEstados, agenteNav, this,destinos);
        buscando = new Buscar(maquinaEstados, agenteNav, this);
        persiguiendo = new Perseguir(maquinaEstados, agenteNav, this);
        maquinaEstados.Inicializar(patrullando);
        for (int y=0;y<destinos.Length;y++)
        {
            destinos[y].y = transform.position.y;
        }
    }
    private void Update()
    {
        maquinaEstados.EstadoActual.Actualizar();
    }
}
