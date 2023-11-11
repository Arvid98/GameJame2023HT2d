using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false; // Start with the game paused
    public TextMeshProUGUI startText;


    void Start()
    {
        TogglePause(); // Call TogglePause to set the initial state
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f;
        }
        else
        {
            // Unpause the game
            startText.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
