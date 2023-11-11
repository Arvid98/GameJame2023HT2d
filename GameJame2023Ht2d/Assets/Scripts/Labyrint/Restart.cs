using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 mousePos;

    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Do something when the specified object enters the trigger zone.
            //Debug.Log("Trigger entered by object with tag 'YourTag'");
            player.position = new Vector2(110,-125);
           

        }
    }
   
}
