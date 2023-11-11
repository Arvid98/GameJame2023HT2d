using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            LevelManager.level = 4;
            SceneManager.LoadScene("Windows");
        }
        deadBoids = 0;

    }
}
