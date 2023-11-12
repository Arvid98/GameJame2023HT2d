using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerVision : MonoBehaviour
{

    public float fov;

    private void OnDrawGizmos()
    {
        //Handles.color = new Color(50, 50,0, 0.3f);
        //Handles.DrawSolidDisc(transform.position, transform.up, fov);
    }


}
