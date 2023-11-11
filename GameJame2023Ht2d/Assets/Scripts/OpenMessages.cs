using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMessages : MonoBehaviour
{
    public GameObject canvasToOpen;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvasToOpen.SetActive(true);
        }
    }
}
