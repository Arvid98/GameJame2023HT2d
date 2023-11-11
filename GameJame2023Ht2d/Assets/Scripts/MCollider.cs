using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCollider : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D collider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Boid"))
        {
            Destroy(collision.gameObject);

        }

    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // This method is called when a collision occurs
    //    Debug.Log("Collision detected with " + collision.gameObject.name);
    //}
}
