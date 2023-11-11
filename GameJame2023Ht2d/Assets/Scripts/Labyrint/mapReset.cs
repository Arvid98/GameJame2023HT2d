using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mapReset : MonoBehaviour
{
    public float currentTime;

    private void Update()
    {
        currentTime = currentTime - Time.deltaTime;

        if(currentTime < 0)
        {
            SceneManager.LoadScene("Labyrint");
        }
    }
}
