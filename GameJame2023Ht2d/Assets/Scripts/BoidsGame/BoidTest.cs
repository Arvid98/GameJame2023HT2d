using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;



public class BoidTest : MonoBehaviour
{

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




    public Vector2 position;
    
    public Vector2 forward;
    Vector2 velocity;

    
    Vector2 acceleration;
    
    public Vector2 avgFlockHeading;
   
    public Vector2 avgAvoidanceHeading;
   
    public Vector2 centreOfFlockmates;

    public int numPerceivedFlockmates;

    // Cached
    Material material;
    Transform cachedTransform;
    Transform target;

    void Awake()
    {
        material = transform.GetComponentInChildren<SpriteRenderer>().material;
        cachedTransform = transform;
    }

    public void Initialize( Transform target)
    {
        this.target = target;
   

        position = cachedTransform.position;
        forward = cachedTransform.up;

        float startSpeed = (minSpeed + maxSpeed) / 2;
        velocity = transform.up * startSpeed;
    }

    public void SetColour(Color col)
    {
        if (material != null)
        {
            material.color = col;
        }
    }

    public void UpdateBoid()
    {
        Vector2 acceleration = Vector2.zero;

        if (target != null)
        {
            Vector2 offsetToTarget = ((Vector2)target.position - position);
            acceleration = SteerTowards(offsetToTarget) * targetWeight;
        }

        if (numPerceivedFlockmates != 0)
        {
            centreOfFlockmates /= numPerceivedFlockmates;

            Vector2 offsetToFlockmatesCentre = (centreOfFlockmates - position);

            var alignmentForce = SteerTowards(avgFlockHeading) * alignWeight;
            var cohesionForce = SteerTowards(offsetToFlockmatesCentre) * cohesionWeight;
            var separationForce = SteerTowards(avgAvoidanceHeading) * seperateWeight;

            acceleration += alignmentForce;
            acceleration += cohesionForce;
            acceleration += separationForce;
        }

        if (IsHeadingForCollision())
        {
            Vector2 collisionAvoidDir = ObstacleRays();
            Vector2 collisionAvoidForce = SteerTowards(collisionAvoidDir) * avoidCollisionWeight;
            acceleration += collisionAvoidForce;
        }

        velocity += acceleration * Time.deltaTime;
        float speed = velocity.magnitude;
        Vector2 dir = velocity.normalized;
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        velocity = dir * speed;

        cachedTransform.position += (Vector3)(velocity * Time.deltaTime);
        cachedTransform.up = dir;
        position = cachedTransform.position;
        forward = dir;
    }

    bool IsHeadingForCollision()
    {
        RaycastHit2D hit = Physics2D.CircleCast(position,boundsRadius, forward,collisionAvoidDst,obstacleMask);
        return hit.collider != null;
    }

    Vector2 ObstacleRays()
    {
        Vector2[] rayDirections = BoidHelperTest.directions;

        for (int i = 0; i < rayDirections.Length; i++)
        {
            Vector3 dir = cachedTransform.TransformDirection(rayDirections[i]);
            Ray ray = new Ray(position, dir);
            RaycastHit2D hit = Physics2D.CircleCast(position, boundsRadius, dir, collisionAvoidDst, obstacleMask);

            if (hit.collider == null)
            {
                return dir;
            }
        }

        return forward;
    }

    Vector2 SteerTowards(Vector2 vector)
    {
        Vector2 v = vector.normalized * maxSpeed - velocity;
        return Vector2.ClampMagnitude(v, maxSteerForce);
    }
}
