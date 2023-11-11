using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMessageBox : MonoBehaviour
{
    public GameObject myGameObject;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.time = 1.1f;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            myGameObject.SetActive(false);
        }
    }
}
