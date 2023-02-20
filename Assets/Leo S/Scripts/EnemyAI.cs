using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float nextWaypointDistance = 3f;

    Path path;

    int currentWaypoint;
    bool reachedWaypoint;

    Seeker seeker;
    Rigidbody2D rb;

    public Animator anim;

    public int health;

    private bool isAttacking;

    private enum State { idle, hurt, death };
    private State state = State.idle;

    public virtual void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("UpdatePath", 0f, .5f);
        
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

    public virtual void Update()
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

        if (targetDistance <= 3.5f && isAttacking == false)
        {
            print("attack");
            StartCoroutine(Attack());
        }

        rb.AddForce(force);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(force.x >= 0.01f)
        {
            transform.localScale = new Vector3(3.7f, 3.7f, 3.7f);
        }
        else if(force.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3.7f, 3.7f, 3.7f);
        }


        anim.SetInteger("state", (int)state);
        StateSwitch();
        if (health <= 0)
        {
            state = State.death;
            StartCoroutine(Die());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            state = State.hurt;
            TakeDamage();
        }
    }


    void TakeDamage()
    {
        health -= 1;
    }
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.4f);
        EnemySpawn.instance.killCount++;
        WaveSystem.instance.EnemyKilled();
        Destroy(gameObject);
    }

    public IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(2.3f);
        Health.instance.TakeDamage();
        Debug.Log("Ez no scope bozo");
        isAttacking = false;

    }
    private void StateSwitch()
    {
        state = State.idle;
    }

}
