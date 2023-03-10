using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;
    public Transform enemyGFX;

    float maxTargetDistance;
    public float nextWaypointDistance = 3f;

    public bool jump;
    public float speed;

    Path path;

    int currentWaypoint;
    bool reachedWaypoint;

    [Header("Attacking")]
    public GameObject projectile;
    public Transform attackPoint;
    public int launchForce;
    float attackTimer;

    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        maxTargetDistance = 7.5f;
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedWaypoint = true;
            return;
        }
        else
        {
            reachedWaypoint = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;


        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        float targetDistance = Vector2.Distance(rb.position, target.position);

        if(targetDistance <= maxTargetDistance)
        {
            rb.AddForce(force);
            maxTargetDistance = 14;
        }
        else if(targetDistance >= maxTargetDistance)
        {
            maxTargetDistance = 7;
        }

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(force.x >= -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(force.x <= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(jump == true)
        {
            rb.AddForce(new Vector2(0, 5));
        }

        //Attacking

        attackTimer += Time.deltaTime;
        if(attackTimer > 3)
        {
            Attack();
            attackTimer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            jump = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            jump = false;
        }
    }

    void Attack()
    {
        GameObject newProjectile = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

}
