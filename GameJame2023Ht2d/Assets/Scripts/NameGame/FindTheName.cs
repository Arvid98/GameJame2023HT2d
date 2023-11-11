using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTheName : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject square;
    Vector2 buttonSize = new Vector2(100, 100);
    Vector2 spawnPoint = new Vector2(-500f, 300f);



    public GameObject ParentPanel;

    void Start()
    {        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {

                SpawnObject(new Vector2(spawnPoint.x + i * buttonSize.x, spawnPoint.y - j * buttonSize.y));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnObject(Vector2 pos) 
    { 
        Instantiate(square, pos, Quaternion.identity, ParentPanel.transform).transform.localPosition= new Vector3(pos.x, pos.y, 0);
    }

    void Select()
    {

    }
}
