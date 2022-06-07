using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Audio Source"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
