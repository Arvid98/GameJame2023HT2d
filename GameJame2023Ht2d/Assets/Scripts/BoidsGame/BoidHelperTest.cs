using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class BoidHelperTest
{

    const int numViewDirections = 300;
    public static readonly Vector2[] directions;

    static BoidHelperTest()
    {
        directions = new Vector2[BoidHelperTest.numViewDirections];

        float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
        float angleIncrement = Mathf.PI * 2 * goldenRatio;

        for (int i = 0; i < numViewDirections; i++)
        {
            float t = (float)i / numViewDirections;
            float angle = angleIncrement * i;

            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);

            directions[i] = new Vector2(x, y);
        }
    }

}