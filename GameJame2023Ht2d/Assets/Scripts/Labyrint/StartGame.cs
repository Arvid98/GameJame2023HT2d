using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private bool isPaused = true; // false för att börja pausad
    public TextMeshProUGUI startText;
    public Transform mus;
    public Transform goal;


    void Awake()
    {
        goal.gameObject.SetActive(false);
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                goal.gameObject.SetActive(true);
                startText.gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    TogglePause();
        //}
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
