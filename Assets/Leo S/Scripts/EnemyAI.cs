using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//Leo S
public class EnemyAI : MonoBehaviour
{
    public Transform target; // varable for the player

    public float speed; // variable for the speed of hte enemy
    

    Path path; // varaible for the path script
    
    //waypoint variables
    int currentWaypoint;
    bool reachedWaypoint;
    public float nextWaypointDistance = 3f;

    Seeker seeker; // variable for the seeker script
    Rigidbody2D rb;// varaibel for rigidbody

    public Animator anim; // animator variable

    public int health; // health variable

    private bool isAttacking; // variable for attacking

    //variables for states
    private enum State { idle, hurt, death };
    private State state = State.idle;

    //refering the seeker variable to the scrpit
    //refering the rb variable to the rigidbosy of the enemy
    //refering the target variable to the player object
    // Invokes the method UpdatePath in time seconds, then repeatedly every repeatRate seconds.
    //sets the speed to 5
    public virtual void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        InvokeRepeating("UpdatePath", 0f, .5f);
        speed = 5;
    }

    // Updates the path of the enemy so that it always knows where to go
    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    // sets path to p and the current waypoint to 0
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
        //if path is null check again
        if (path == null)
            return;
        //if you reach a waypoint it resets the waypoint
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedWaypoint = true;
            return;
        }
        else
        {
            reachedWaypoint = false;
        }

        // calculates the direction to the target
        //adds a force to the direction of the target
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        // the distance between the enemy and the next nawpoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        //the distance to the player
        float targetDistance = Vector2.Distance(rb.position, target.position);

        //if the distance between the target and the enemy is less than 2 and the enemy isnt attakcing
        //its start to attack
        //if the distance between the enemy and player is more than 2 the enemy stops attacking
        if (targetDistance <= 2f && isAttacking == false)
        {
            print("attack");
            StartCoroutine(Attack());
        }
        if (targetDistance >= 2f)
        {
            isAttacking = false;
        }

        //if the distance to the next waypoint is less than the nextwaypointdistance it adds 1 to current waypoint
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        //if the force is more than .1 it flips the player to the right
        //if the force is less than -.1 it flips the player to the left
        if(force.x >= 0.01f)
        {
            transform.localScale = new Vector3(3.7f, 3.7f, 3.7f);
        }
        else if(force.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3.7f, 3.7f, 3.7f);
        }


        anim.SetInteger("state", (int)state); // Animates the boss depending on what state the boss is in
        StateSwitch(); // the stateswích function
        //If the enemys health is lesser than 0 it switches the enemys state to death and starts the die coroutine
        if (health <= 0)
        {
           state = State.death;
           StartCoroutine(Die());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the enemy gets hit by a bullet it triggers the Takedamage function and changes the enemys state to hurt
        if (collision.transform.tag == "Bullet")
        {
            state = State.hurt;
            TakeDamage();
        }
    }


    // it subtracts 1 from the enemys health
    void TakeDamage()
    {
        health -= 1;
    }
    //It waits .4 seconds
    // triggers the EnemyKilled function of the Wavesystem script 
    //Destroys the enemy
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.4f);
        WaveSystem.instance.EnemyKilled();
        Destroy(gameObject);
    }

    //sets attacking to true
    //waits 2.3 seconds
    //Triggers the takeDamage funciton of the health script
    //sets attacking to false
    public IEnumerator Attack()
    {
        isAttacking = true;
        if (isAttacking)
        {
            yield return new WaitForSeconds(2.3f);
            Health.instance.TakeDamage();
            isAttacking = false;
        }

    }
    //sets the state of the enemy to idle
    private void StateSwitch()
    {
        state = State.idle;
    }

}
