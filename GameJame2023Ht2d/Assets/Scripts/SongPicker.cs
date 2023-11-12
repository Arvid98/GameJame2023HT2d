using UnityEngine;

public class SongPicker : MonoBehaviour
{
    public int songNumber = 0;
    public GameObject mediaPlayerWindow;
    MusicPlayerScript musicPlayer;
    private void Awake()
    {
        musicPlayer = FindObjectOfType<MusicPlayerScript>();
         // Replace with the actual name

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0))
        {
            
            // Check if the component is found
            if (musicPlayer != null)
            {
                // Call the SongPlayer method from the parent object
                musicPlayer.SongPlayer(songNumber);
            }
            else
            {
                Debug.LogError("MusicPlayerScript not found in parent objects.");
            }

        }
        // Attempt to find the MusicPlayerScript component in parent objects
    }

    
}
