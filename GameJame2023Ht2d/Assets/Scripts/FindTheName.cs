using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheName : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    Vector2 spawnPoint = new Vector2(-6.5f, 2.5f);

    void Start()
    {        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                SpawnObject(new Vector2(spawnPoint.x + i, spawnPoint.y - j));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObject(Vector2 pos) 
    { 
        Instantiate(square, pos, Quaternion.identity);
    }
}
