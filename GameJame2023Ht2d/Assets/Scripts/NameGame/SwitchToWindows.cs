using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToWindows : MonoBehaviour
{
    FindTheName findTheName;
    // Start is called before the first frame update
    void Start()
    {
        findTheName = GetComponent<FindTheName>();
    }

    public void ExitClick()
    {
        if (findTheName.win)
        {
            Cursor.visible = false;
            LevelManager.level = 2;
            SceneManager.LoadScene("Windows");

        }
    }
}
