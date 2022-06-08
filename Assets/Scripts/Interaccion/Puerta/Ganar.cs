using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("ganar");
        
    }
    IEnumerator ganar()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Victoria");
    }
}
