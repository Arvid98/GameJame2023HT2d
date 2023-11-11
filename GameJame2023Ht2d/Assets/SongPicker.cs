using UnityEngine;

public class SongPicker : MonoBehaviour
{
    public int songNumber = 0;
    public GameObject mediaPlayer;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0) && mediaPlayer.active)
        {
            MusicPlayerScript musicPlayer = gameObject.GetComponentInParent<MusicPlayerScript>();

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
