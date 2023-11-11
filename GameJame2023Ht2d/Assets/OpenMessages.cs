using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMessages : MonoBehaviour
{
    private BoxCollider2D myCollider;
    public bool messageBoxIsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider != null && myCollider.isTrigger)
        {
            messageBoxIsOpen= true;
        }
    }
}
