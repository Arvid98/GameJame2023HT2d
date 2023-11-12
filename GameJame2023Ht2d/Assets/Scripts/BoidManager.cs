using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoidManager : MonoBehaviour
{
    public Boid[] boidsArray;
    int deadBoids = 0;
    Vector2 mid = Vector2.zero;
    void Start()
    {
       

       
    }
    public Vector2 CalculateMid()
    {
        Vector2 mid = Vector2.zero;
        foreach (Boid boid in boidsArray)
        {
            mid += (Vector2)boid.transform.position;
        }

        return mid /= boidsArray.Length;
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


