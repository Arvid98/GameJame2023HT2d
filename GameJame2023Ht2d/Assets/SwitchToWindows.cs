using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToWindows : MonoBehaviour
{
    FindTheName findTheName;
    // Start is called before the first frame update
    void Start()
    {
        findTheName = GetComponent<FindTheName>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetMouseButton(0) && findTheName.win) 
        {
            LevelManager.level = 2;
            SceneManager.LoadScene("Windows");
        }
    }
}
