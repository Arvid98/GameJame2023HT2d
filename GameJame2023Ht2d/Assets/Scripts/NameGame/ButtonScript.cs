using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public FindTheName owner;
    public Vector2 pos;
    public bool activeButton;
    void Start()
    {
        activeButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        GetComponent<UnityEngine.UI.Button>().interactable = false;
        activeButton = true;
        owner.Check(this);
    }
    public void ResetButton()
    {
        GetComponent<UnityEngine.UI.Button>().interactable = true;
        activeButton = false;
    }
}
