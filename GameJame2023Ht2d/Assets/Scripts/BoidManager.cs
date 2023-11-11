using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public Boid[] boidsArray;
    int deadBoids = 0;
    void Start()
    {
       foreach (Boid boid in boidsArray )
       {
            
       }
    }

   
    void Update()
    {       
        foreach (Boid boid in boidsArray)
        {
            if(boid.dead == true)
            {
                deadBoids++;

            }
        }
        if (deadBoids >= boidsArray.Length)
        {
            Debug.Log("all dead");
        }
        deadBoids = 0;

    }
}
