using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;


public class BoidManagerTest : MonoBehaviour
{

    const int threadGroupSize = 1024;

   


    public ComputeShader compute;
    BoidTest[] boids;



    public float minSpeed = 2;
    public float maxSpeed = 5;
    public float perceptionRadius = 2.5f;
    public float avoidanceRadius = 1;
    public float maxSteerForce = 3;

    public float alignWeight = 1;
    public float cohesionWeight = 1;
    public float seperateWeight = 1;

    public float targetWeight = 1;


    public LayerMask obstacleMask;
    public float boundsRadius = .27f;
    public float avoidCollisionWeight = 10;
    public float collisionAvoidDst = 5;

    void Start()
    {
        boids = FindObjectsOfType<BoidTest>();
        foreach (BoidTest b in boids)
        {
            b.Initialize( null);
        }

    }

    void Update()
    {
        if (boids != null)
        {

            int numBoids = boids.Length;
            var boidData = new BoidData[numBoids];

            for (int i = 0; i < boids.Length; i++)
            {
                boidData[i].position = new Vector2(boids[i].position.x, boids[i].position.y);
                boidData[i].direction = new Vector2(boids[i].forward.x, boids[i].forward.y);
            }

            var boidBuffer = new ComputeBuffer(numBoids, BoidData.Size);
            boidBuffer.SetData(boidData);

            //compute.SetBuffer(0, "boids", boidBuffer);
            //compute.SetInt("numBoids", boids.Length);
            //compute.SetFloat("viewRadius", perceptionRadius);
            //compute.SetFloat("avoidRadius", avoidanceRadius);

            int threadGroups = Mathf.CeilToInt(numBoids / (float)threadGroupSize);
            //compute.Dispatch(0, threadGroups, 1, 1);

            boidBuffer.GetData(boidData);

            for (int i = 0; i < boids.Length; i++)
            {
                boids[i].avgFlockHeading = new Vector3(boidData[i].flockHeading.x, boidData[i].flockHeading.y, 0);
                boids[i].centreOfFlockmates = new Vector3(boidData[i].flockCentre.x, boidData[i].flockCentre.y, 0);
                boids[i].avgAvoidanceHeading = new Vector3(boidData[i].avoidanceHeading.x, boidData[i].avoidanceHeading.y, 0);
                boids[i].numPerceivedFlockmates = boidData[i].numFlockmates;

                boids[i].UpdateBoid();
            }

            boidBuffer.Release();
        }
    }

    public struct BoidData
    {
        public Vector2 position;
        public Vector2 direction;

        public Vector2 flockHeading;
        public Vector2 flockCentre;
        public Vector2 avoidanceHeading;
        public int numFlockmates;

        public static int Size
        {
            get
            {
                return sizeof(float) * 2 * 5 + sizeof(int);
            }
        }
    }
}

