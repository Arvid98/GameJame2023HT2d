using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
   public void Button1()
    {
        LevelManager.level = 4;
        SceneManager.LoadScene("Windows");
    }
}
