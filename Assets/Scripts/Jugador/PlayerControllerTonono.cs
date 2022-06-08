using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerTonono : MonoBehaviour
{
    [SerializeField] Text textoui;
    [SerializeField] private Camera miCamara;
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;
    RaycastHit miRayito;
    public bool tengoLlave = false;
    private bool contactoConLlave = false;
    public static PlayerControllerTonono Instancia { get; private set; }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((transform.right * horizontal + transform.forward * vertical) * Time.deltaTime);

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PuertaLlave")
        {
            if (tengoLlave==false)
            {
                textoui.text = "Para poder pasar necesitas una llave, normalmente la profesora que esta en esta planta la suele llevar encima";
            }
            else
            {
                textoui.text = "Ya tienes la llave pulsa E para abrir la puerta";
            }
        }
        else
        {
            textoui.text = "";
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Zombie")
        {
            hasPerdido();
        }
    }
    private void hasPerdido()
    {
        miCamara.transform.SetParent(transform.parent);
        //Destroy(this.gameObject);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        miCamara.transform.position += new Vector3(-5, 5, 0);
        miCamara.transform.Rotate(50, 0, 0);
        textoui.text = "HAS MUERTO";
        StartCoroutine("empezarNuevo");
    }
    
        private void OnTriggerExit(Collider other)
    {
        contactoConLlave = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Llave")
        {
            contactoConLlave = true;
        }
    }
    public void OnInteraccion()
    {
        if ((contactoConLlave)&&(tengoLlave==false))
        {
            tengoLlave = true;
            EscuchadorEventos.LlavePillada();
        }
    }
    IEnumerator empezarNuevo()
    {
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        SceneManager.LoadScene("menu");
    }
}