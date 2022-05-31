using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public Button botonSalir;
    public AudioSource source;
    public AudioClip clip;
    public void pulsarBotonSalir()
    {
        botonSalir.enabled = false;
        source.PlayOneShot(clip);
        StartCoroutine("salirJuego");
    }
    IEnumerator salirJuego()
    {
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("menu");
    }
}
