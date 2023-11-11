using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject mediaPlayer;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0) && mediaPlayer.active)
        {
            MusicPlayerScript musicPlayer = gameObject.GetComponentInParent<MusicPlayerScript>();

            // Check if the component is found
            if (musicPlayer != null)
            {
                musicPlayer.PauseOrPlay();
                // Call the SongPlayer method from the parent object
                
            }
            else
            {
                Debug.LogError("MusicPlayerScript not found in parent objects.");
            }
        }
    }
}
