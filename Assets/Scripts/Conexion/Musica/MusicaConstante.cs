using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaConstante : MonoBehaviour
{
    private void Awake()
    {  
        if (SceneManager.GetActiveScene().name != "EscenarioJuego") {
            GameObject[] musica = GameObject.FindGameObjectsWithTag("GameMusic");
            if (musica.Length > 1)
            {
                Destroy(this.gameObject);
            }
        DontDestroyOnLoad(this.gameObject);
        }
    }
}
