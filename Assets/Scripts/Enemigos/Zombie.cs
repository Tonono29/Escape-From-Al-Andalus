using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private bool esperando = false;
    [SerializeField]private bool hordaZombie;
    private NavMeshAgent agenteNav;
    [SerializeField] public Vector3[] destinos;
    public MaquinaEstados maquinaEstados;
    public Patrullando patrullando;
    public Buscar buscando;
    public Perseguir persiguiendo;
    //public Perseguir perseguir;

    private void Awake()
    {
        agenteNav = GetComponent<NavMeshAgent>();
        if (hordaZombie)
        {
            DestinosHorda();
        }
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
    private void DestinosHorda()
    {
        for (int i = 0; i < 4; i++)
        {
            float x;
            float z;
            x = Random.Range(-3.0f, 3.0f);
            z = Random.Range(-3.0f, 3.0f);
            destinos[i] = transform.position + new Vector3(x, 0, z);
        }
    }
    public void IniciarEspera()
    {
        esperando = true;
        while (esperando)
        {
            StartCoroutine("Esperar");
        }
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(4);
        esperando = false;
    }
}
