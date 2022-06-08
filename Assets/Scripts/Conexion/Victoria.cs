using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Victoria : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = true;
    }
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
        Process.Start(Application.dataPath + "/../Escape From Al-Andalus.exe");
        Application.Quit();
    }
}
