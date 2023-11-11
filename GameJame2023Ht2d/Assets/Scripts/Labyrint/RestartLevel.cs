using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject hitObject = other.gameObject;
        if (hitObject.tag == "Player")
        {
            SceneManager.LoadScene("Labyrint");
            Debug.Log("test");
        }
    }
}
