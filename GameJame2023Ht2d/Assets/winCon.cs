using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCon : MonoBehaviour
{
    public GameObject winScreen;
    public int levelCap;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.level >= levelCap)
        {
            winScreen.SetActive(true);
        }
    }
}
