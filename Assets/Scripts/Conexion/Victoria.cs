using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        //Process.Start(Application.dataPath + "/../Escape From Al-Andalus.exe");
        Application.Quit();
    }
    public void MenuPcpal()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
}
