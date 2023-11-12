using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject mediaPlayerWindow;
    MusicPlayerScript musicPlayer;
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void Awake()
    {
        musicPlayer = FindObjectOfType<MusicPlayerScript>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        // Check if the component is found
        if (Input.GetMouseButton(0))
        {
            musicPlayer.PauseOrPlay();
            // Call the SongPlayer method from the parent object

        }
        
    }
}

