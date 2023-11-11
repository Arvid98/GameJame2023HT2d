using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMessages : MonoBehaviour
{
    public GameObject canvasToOpen;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButton(0))
        {
            
            canvasToOpen.SetActive(true);
        }
    }
}
