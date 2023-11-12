using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioClip[] AudioClips;
    public  AudioSource audioSource;
    bool isPaused = false;
    private static MusicPlayerScript instance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reinitialize the music player as needed
        // For example, stop the current song and play a new one
         // Implement PlayNewSong according to your logic
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void PauseOrPlay()
    {
        if(isPaused)
        {
        audioSource.Play();
        isPaused = false;
        }
        else
        {
        audioSource.Pause();
        isPaused = true;
        }

    }
    public void SongPlayer(int songnumber)
    {
        audioSource.clip = AudioClips[songnumber];
        audioSource.Play();
    }
   

    
}
