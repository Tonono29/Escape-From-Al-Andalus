using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ControllerJugador : MonoBehaviour
{
    [SerializeField] private float jugadorVelocidad = 2.0f;
    [SerializeField] private float jugadorSaltoAltura = 1.0f;
    [SerializeField] private float jugadorGravedad = -9.81f;

    private CharacterController controller;
    private InputManager inputManager;
    private Vector3 characterVelocidad;
    private bool enSueloCharacter;
    private Transform camaraTransform;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        camaraTransform = Camera.main.transform;
    }

    void Update()
    {
        enSueloCharacter = controller.isGrounded;
        if(enSueloCharacter && characterVelocidad.y < 0)
        {
            characterVelocidad.y = 0f;
        }

        Vector2 move = inputManager.jugadorGetMovimiento();
        Vector3 movimiento = new Vector3(move.x, 0f, move.y);
        movimiento = camaraTransform.forward * movimiento.z + camaraTransform.right * movimiento.x;
        movimiento.y = 0f;
        controller.Move(movimiento * Time.deltaTime * jugadorVelocidad);

        /*
        if(movimiento != Vector3.zero)
        {
            gameObject.transform.forward = movimiento;
        }
        */
        if(inputManager.jugadorSalta() && enSueloCharacter)
        {
            characterVelocidad.y += Mathf.Sqrt(jugadorSaltoAltura * -3.0f * jugadorGravedad);
        }
        characterVelocidad.y += jugadorGravedad * Time.deltaTime;
        controller.Move(characterVelocidad * Time.deltaTime);
    }
}
