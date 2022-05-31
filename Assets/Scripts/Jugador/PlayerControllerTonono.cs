using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTonono : MonoBehaviour
{
    [SerializeField] Text textoui;
    [SerializeField] private Camera miCamara;
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 0;
    RaycastHit miRayito;
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
        if (Physics.Raycast(miCamara.transform.position, miCamara.transform.forward, out miRayito, 5))
        {
            if (miRayito.transform.gameObject.tag == "Puerta")
            {
                miRayito.transform.gameObject.GetComponent<InteraccionPuerta>().MostrarUiPuertas();
            }
            else
            {
                textoui.text = "";
            }
            Debug.DrawRay(miCamara.transform.position, miCamara.transform.forward, Color.yellow);
        }
    }
    public void OnInteraccion()
    {
        if (Physics.Raycast(miCamara.transform.position, miCamara.transform.forward, out miRayito, 5))
        {
            if (miRayito.transform.gameObject.tag == "Puerta")
            {
                EscuchadorEventos.AbrirCerrarPuerta(miRayito.transform.gameObject);
            }
        }
    }
}