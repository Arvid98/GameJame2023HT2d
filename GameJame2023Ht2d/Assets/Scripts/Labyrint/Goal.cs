using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public List<GameObject> mapList; 
    //public Transform map;

    Transform chosenMap;
    public Transform timer;
    public TextMeshProUGUI timerText;
    bool goalReached = false;
    float countDown = 2;

    private void Start()
    {
        popupText.gameObject.SetActive(false);
        System.Random random = new System.Random();
        int intMap=random.Next(0,3);
        chosenMap = mapList[intMap].transform;
        chosenMap.gameObject.SetActive(true);
        
    }

    private void Update()
    {
        if (goalReached)
        {
            countDown = countDown - Time.deltaTime;

            if (countDown < 0)
            {
                SceneManager.LoadScene("Labyrint");

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chosenMap.gameObject.SetActive(false);
            timer.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            
            popupText.gameObject.SetActive(true);
            popupText.text = "VIRUS TRANSFERED";
            goalReached= true;

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
