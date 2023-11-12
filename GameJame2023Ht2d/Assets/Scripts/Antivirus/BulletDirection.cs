using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BulletDirection : MonoBehaviour
{
    public float bulletSpeed = 10;
    
    public Vector2 mousePos;
    public Vector2 direction;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject mouse = GameObject.Find("cursor-21");
        mousePos = new Vector2(mouse.transform.position.x, mouse.transform.position.y);
        direction = mousePos.normalized;
    }

    private void Update()
    {
        rb.velocity = direction * bulletSpeed;
        
    }

}
