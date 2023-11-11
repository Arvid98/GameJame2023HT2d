using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerDuration = 2f; 
    private float timer;
    public float xTiemr =1f;
    public float yTiemr = 1f;
    public float radius = 5f;
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
            xTiemr = Random.Range(-2f, 2f);
            yTiemr = Random.Range(-2f, 2f);
            radius = Random.Range(0, 7f);
           timer = timerDuration;
        }
    }
}
