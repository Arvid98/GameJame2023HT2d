using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioClip[] AudioClips;
    public  AudioSource AudioSource;
    bool isPaused = false;  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void PauseOrPlay()
    {
        if(isPaused)
        {
        AudioSource.Play();
        isPaused = false;
        }
        else
        {
        AudioSource.Pause();
        isPaused = true;
        }

    }
    public void SongPlayer(int songnumber)
    {
        AudioSource.clip = AudioClips[songnumber];
        AudioSource.Play();
    }
   

    
}
