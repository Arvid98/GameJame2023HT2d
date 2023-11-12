using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCon : MonoBehaviour
{
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if(LevelManager.level == 6)
        {
            winScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
