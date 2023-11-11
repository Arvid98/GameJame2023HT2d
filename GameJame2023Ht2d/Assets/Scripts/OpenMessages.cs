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
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 1.1f;
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            canvasToOpen.SetActive(true);
        }
    }
}
