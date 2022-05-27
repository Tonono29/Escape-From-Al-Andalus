using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaConstante : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musica = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musica.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
