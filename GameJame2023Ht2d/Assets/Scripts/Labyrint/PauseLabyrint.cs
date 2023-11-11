using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseLabyrint : MonoBehaviour
{
    private bool isPaused = false; // Start with the game paused
    public TextMeshProUGUI startText;
    public Transform mus;

    private void Awake()
    {
        mus.position = new Vector2(110, -125);
    }
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
