using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButton(0))
        {
            Application.Quit();
        }
    }
}
