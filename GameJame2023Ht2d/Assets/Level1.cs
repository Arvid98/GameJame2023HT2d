using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    public string levelName;
    public int levelCap;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && LevelManager.level == levelCap && Input.GetMouseButton(0))
        {

            SceneManager.LoadScene(levelName);
        }
    }
}
