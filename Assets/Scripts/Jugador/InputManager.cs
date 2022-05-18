using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private Controles jugadorControles;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        jugadorControles = new Controles();
        Cursor.visible = false;
    }
    private void OnEnable() => jugadorControles.Enable();
    private void OnDisable() => jugadorControles.Disable();

    public Vector2 jugadorGetMovimiento()
    {
        return jugadorControles.Jugador.Mover.ReadValue<Vector2>();
    }
    public Vector2 jugadorGetRaton()
    {
        return jugadorControles.Jugador.Mirar.ReadValue<Vector2>();
    }
    public bool jugadorSalta()
    {
        return jugadorControles.Jugador.Saltar.triggered;
    }
}
