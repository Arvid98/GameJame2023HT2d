using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoidHelper
{
    const int numViewDirections = 300;
    public static readonly Vector2[] directions2D;

    static BoidHelper()
    {
        directions2D = new Vector2[numViewDirections];

        float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
        float angleIncrement = Mathf.PI * 2 * goldenRatio;

        for (int i = 0; i < numViewDirections; i++)
        {
            float t = (float)i / numViewDirections;
            float angle = angleIncrement * i;

            float x = Mathf.Cos(angle);
            float y = Mathf.Sin(angle);
            directions2D[i] = new Vector2(x, y);
        }
    }
}
