using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid grid;

    private void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20, 0));
        new Grid(2, 5, 5f, new Vector3(0, -20));
        new Grid(10, 10, 20f, new Vector3(-100, -20));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);

        }
    }
}
