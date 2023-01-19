using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrackingProjectile : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;

    public float nextWaypointDistance = 3f;

    public float speed;

    Path path;

    int currentWaypoint;
    bool reachedWaypoint;


    Seeker seeker;
    Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
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

         rb.AddForce(force); 

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (force.x <= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }


}
