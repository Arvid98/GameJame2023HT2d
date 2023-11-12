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
    [SerializeField] BoidManager boidManager;
    Vector2 mid;
    [SerializeField] int deivder = 10;


    void Start()
    {
        mid = Vector2.zero;
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
            mid = boidManager.CalculateMid();
            if(mid.x > deivder)
            {
              
                xTiemr = Random.Range(0f, -2f);
            }
            else if(mid.x < -deivder)
            {
                xTiemr = Random.Range(2f, 0);
            }
            else
            {
                xTiemr = Random.Range(-2f, 2f);
            }

            if( mid.y > deivder)
            {
                
               
                yTiemr = Random.Range(0, -2f);
            }
            else if(mid.y < -deivder)
            {

                yTiemr = Random.Range(2f, 0);
            }
            else
            {

               yTiemr = Random.Range(-2f, 2f);
                radius = Random.Range(0, 7f);
               
            }
            timer = timerDuration;

        }
    }
}
