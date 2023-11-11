using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    private float timer = 0f;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Increment the timer with the time passed since the last frame


        if (LevelManager.level % 2 == 0 || LevelManager.level == 0)
        {
            if (timer >= 1f)
            {
                if (sr.enabled)
                    sr.enabled = false;
                else
                    sr.enabled = true;
                // Replace this with your desired logic
                timer = 0f; // Reset the timer
            }
        }
        else
        {
            sr.enabled = false;
        }
    }
}
