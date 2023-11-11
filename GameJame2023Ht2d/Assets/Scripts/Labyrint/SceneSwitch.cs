using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
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

