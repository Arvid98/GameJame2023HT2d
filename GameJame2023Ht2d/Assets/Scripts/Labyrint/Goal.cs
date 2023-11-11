using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI popupText; // Reference to the Text component for displaying the message
    public Transform map;
    public Transform timer;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        popupText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            map.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            
            popupText.gameObject.SetActive(true);
            popupText.text = "VIRUS TRANSFERED";


        }
      
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player")) // Check if the colliding object is the player
    //    {
    //        // Hide the text when the player exits the trigger zone
    //        if (popupText != null)
    //        {
    //            popupText.gameObject.SetActive(false);
    //        }
    //    }
    //}
}
