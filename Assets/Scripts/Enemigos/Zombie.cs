using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public AudioClip impact;
    private Rigidbody miCuerpo;
    private Animator animatorZombie;
    public bool esperando = false;
    [SerializeField]private bool hordaZombie;
    private NavMeshAgent agenteNav;
    [SerializeField] public Vector3[] destinos;
    public MaquinaEstados maquinaEstados;
    public Patrullando patrullando;
    public Buscar buscando;
    public Perseguir persiguiendo;
    public float distanciREstante;
    public Vector3 amosaver;
    public float factorCorreccionAltura;
    private void Awake()
    {
        EscuchadorEventos.OnJugadorEncontrado += JugadorEncontrado;
        miCuerpo = GetComponentInChildren<Rigidbody>();
        animatorZombie = GetComponent<Animator>();
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
        amosaver = agenteNav.destination;
        distanciREstante = agenteNav.remainingDistance;
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
    private void FixedUpdate()
    {
        if (this.agenteNav.velocity.magnitude > 0.3)
        {
            animatorZombie.SetBool("Moviendo", true);
        }
        else
        {
            animatorZombie.SetBool("Moviendo", false);
        }
 
    }
    public void JugadorEncontrado(GameObject jugador, GameObject sombie)
    {
        if ((sombie == this.gameObject) && (maquinaEstados.EstadoActual != persiguiendo))
        {
            persiguiendo.jugadorEncontrado = jugador;
            GetComponent<AudioSource>().PlayOneShot(impact, 1F);
            maquinaEstados.CambiarEstado(persiguiendo);
        }
    }
}
