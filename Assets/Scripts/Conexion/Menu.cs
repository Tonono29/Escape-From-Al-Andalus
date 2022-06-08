using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button botonJugar;
    public Button botonCreditos;
    public Button botonSalir;
    public AudioSource source;
    public AudioClip clip;

    public void pulsarBotonJugar()
    {
        botonJugar.enabled = false;
        botonCreditos.enabled = false;
        botonSalir.enabled = false;
        source.PlayOneShot(clip);
        StartCoroutine("cargarConexion");
    }
    public void pulsarBotonCreditos()
    {
        botonJugar.enabled = false;
        botonCreditos.enabled = false;
        botonSalir.enabled = false;
        source.PlayOneShot(clip);
        StartCoroutine("cargarCreditos");
    }
    public void pulsarBotonSalir()
    {
        botonJugar.enabled = false;
        botonCreditos.enabled = false;
        botonSalir.enabled = false;
        source.PlayOneShot(clip);
        StartCoroutine("salirJuego");
    }

    IEnumerator cargarConexion()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EscenarioJuego",LoadSceneMode.Single);
    }
    IEnumerator cargarCreditos()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("creditos",LoadSceneMode.Single);
    }
    IEnumerator salirJuego()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
