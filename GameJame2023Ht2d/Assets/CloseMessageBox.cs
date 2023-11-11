using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMessageBox : MonoBehaviour
{
    GameObject myGameObject;
    private void Start()
    {
        myGameObject = GetComponent<GameObject>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myGameObject.SetActive(true);
        }
    }
}
