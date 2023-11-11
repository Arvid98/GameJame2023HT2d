using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerDuration = 10f; 
    private float timer;
    public float xTiemr;
    public float yTiemr;

    void Start()
    {
        // Initialize the timer
        timer = timerDuration;
    }

    void Update()
    {
      
        if (timer > 0f)
        {
            timer -= Time.deltaTime; 
        }
        else
        {          
            xTiemr = -1f;
            yTiemr = -1f;
            Debug.Log("Timer has expired!");         
            timer = timerDuration;
        }
    }
}
