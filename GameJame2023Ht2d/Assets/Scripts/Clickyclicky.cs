using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickyclicky : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioSource.clip, 1.0f); // Adjust volume if needed
        }
    }
}
