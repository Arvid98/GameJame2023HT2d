using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;





struct BoidCompute
{
    static int threadGroupSize = 1024;
    float3 position;
    float3 direction;

    float3 flockHeading;
    float3 flockCentre;
    float3 separationHeading;
    int numFlockmates;
};

