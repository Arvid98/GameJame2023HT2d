using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform mouse;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    Vector2 direction;



    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            
        //}
        direction = new Vector2(mouse.position.x - transform.position.x, mouse.position.y - transform.position.y);
        transform.up = direction.normalized;

        
    }

    public void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
            //var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }


    //// Get the mouse position in world space
    //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //// Calculate the direction from the cannon to the mouse
    //Vector3 direction = mousePos - transform.position;
    //direction.z = 0; // Ensure the direction is in the 2D plane

    //    // Rotate the cannon to face the mouse direction
    //    transform.up = direction.normalized;



    void SpawnBullets()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        
    }
}
