using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(Rigidbody2D))]
public class Boid : MonoBehaviour
{
    public float minSpeed = 8;
    public float maxSpeed = 15;
    public float perceptionRadius = 2.5f;
    public float avoidanceRadius = 1;
    public float maxSteerForce = 3;

    public LayerMask obstacleMask;
    public float boundsRadius = .27f;
    public float avoidCollisionWeight = 10;
    public float collisionAvoidDst = 5;

    public float speed = 2.0f;
    public float rotationSpeed = 1.0f;
    public float neighborRadius = 10.0f;

    public float x = 1;
    public float y = 1;

    public float maxFlyForce = 10;

    private List<GameObject> allBoids;
    private Rigidbody2D rb;

    [SerializeField] float distanceBetween;
    private float distance;

    [SerializeField] GameObject player;
    [SerializeField] GameObject wall;

    private Vector2 targetPosition;
    bool shouldFlee;
    public bool dead;
    [SerializeField] Timer timer;
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        allBoids = new List<GameObject>(GameObject.FindGameObjectsWithTag("Boid"));

        dead = false;
         rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyObject != null)
        {
            targetPosition = enemyObject.transform.position;
        }
        else
        {

            targetPosition = new Vector2(0f, 0f);
        }
    }

    void Update()
    {
       
        Vector2 flowDirection = GetFlowDirection();
        Vector2 separation = Separate();
        Vector2 alignment = Align();
        Vector2 cohesion = Cohere();
        Vector2 avoid = Avoid();
        Vector2 noise = GetNoise();



       

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle2 = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, -speed * 2.5f * Time.deltaTime);
            transform.position = Vector2.MoveTowards(this.transform.position, wall.transform.position, -speed * 2 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle2);
        }

        Vector2 moveDirection = separation + cohesion + alignment + avoid + flowDirection + noise;
 
        rb.velocity = moveDirection.normalized * speed;

        // Rotation
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        //rb.rotation += angle * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(Vector3.forward * -angle);



        if (IsHeadingForCollision())
        {
            Vector2 collisionAvoidDir = ObstacleRays();
            Vector2 collisionAvoidForce = SteerTowards(collisionAvoidDir) * avoidCollisionWeight;
            rb.velocity += collisionAvoidForce;
        }
    }

    Vector2 GetFlowDirection()
    {

        x = timer.xTiemr;
        y = timer.yTiemr;
        return new Vector2(x, y);
    }


    Vector2 Flee(Vector2 fleeTarget)
    {

        Vector2 fleeDirection = rb.position - fleeTarget;


        fleeDirection.Normalize();
        fleeDirection *= maxSpeed;


        Vector2 fleeForce = fleeDirection - rb.velocity;


        return Vector2.ClampMagnitude(fleeForce, maxFlyForce);
    }


    Vector2 SteerTowards(Vector2 vector)
    {
        Vector2 v = vector.normalized * maxSpeed - rb.velocity;
        return Vector2.ClampMagnitude(v, maxSteerForce);
    }

    Vector2 ObstacleRays()
    {
        Vector2[] rayDirections = BoidHelper.directions2D;

        for (int i = 0; i < rayDirections.Length; i++)
        {
            Vector2 dir = rb.GetRelativeVector(rayDirections[i]);
            RaycastHit2D hit = Physics2D.Raycast(rb.position, dir, collisionAvoidDst, obstacleMask);

            if (hit.collider == null)
            {
                return dir;
            }
        }

        return rb.velocity.normalized;
    }

    bool IsHeadingForCollision()
    {
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, boundsRadius, rb.velocity.normalized, collisionAvoidDst, obstacleMask);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    bool IsRunning()
    {
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, boundsRadius, rb.velocity.normalized, collisionAvoidDst, obstacleMask);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        // Om Boid-kollision med väggen, ändra riktning
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Ändra riktningen när en kollision med väggen inträffar
            Vector2 reflectDirection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
            rb.velocity = reflectDirection * speed;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Ändra riktningen när en kollision med väggen inträffar
            gameObject.GetComponent<Renderer>().material.color = Color.red; 
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            dead = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }
    Vector2 Separate()
    {
        Vector2 separation = Vector2.zero;
        foreach (GameObject boid in allBoids)
        {
            if (boid != gameObject) // Exclude self
            {
                float distance = Vector2.Distance(transform.position, boid.transform.position);
                if (distance < neighborRadius)
                {
                    Vector2 moveAway = (Vector2)transform.position - (Vector2)boid.transform.position;
                    separation += moveAway.normalized / distance;
                }
            }
        }
        return separation;
    }

    Vector2 Align()
    {
        Vector2 alignment = Vector2.zero;
        int count = 0;

        foreach (GameObject boid in allBoids)
        {
            if (boid != gameObject) // Exclude self
            {
                float distance = Vector2.Distance(transform.position, boid.transform.position);
                if (distance < neighborRadius)
                {
                    alignment += (Vector2)boid.transform.up;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            alignment /= count;
        }

        return alignment;
    }

    Vector2 Cohere()
    {
        Vector2 cohesion = Vector2.zero;
        int count = 0;

        foreach (GameObject boid in allBoids)
        {
            if (boid != gameObject) // Exclude self
            {
                float distance = Vector2.Distance(transform.position, boid.transform.position);
                if (distance < neighborRadius)
                {
                    cohesion += (Vector2)boid.transform.position;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            cohesion /= count;
            cohesion = cohesion - (Vector2)transform.position;
        }

        return cohesion;
    }

    Vector2 Avoid()
    {
        Vector2 avoidance = Vector2.zero;
        foreach (GameObject boid in allBoids)
        {
            if (boid != gameObject) // Exclude self
            {
                float distance = Vector2.Distance(transform.position, boid.transform.position);
                if (distance < neighborRadius)
                {
                    Vector2 moveAway = (Vector2)boid.transform.position - (Vector2)transform.position;
                    avoidance += moveAway.normalized / distance;
                }
            }
        }
        return -avoidance;
    }

    Vector2 GetNoise()
    {
        return new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
    }
}
