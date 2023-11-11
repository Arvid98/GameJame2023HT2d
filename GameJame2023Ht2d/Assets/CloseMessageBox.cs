using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMessageBox : MonoBehaviour
{
    public GameObject myGameObject;
    private void Start()
    {
       
    }
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButton(0))
        {
            
            myGameObject.SetActive(false);
        }
    }
}
