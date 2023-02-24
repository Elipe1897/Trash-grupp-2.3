using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Leo S
public class Boss : MonoBehaviour
{
    [SerializeField] private AudioSource bossSoundEffect; // varaible for the audiosource
    public Transform target; // variable for the player 

    public GameObject [] scrap; // variable for the scrap projectile
    public Transform attackPoint; // a variable for where the scrap projectile will spawn
    public int launchForce; // how fast the scrap will be shot
    float attackTimer; // when the boss will attack
    public float attackDistance; // how far distance it has to be for the boss to attack

    //variables for the states
    private enum State { idle, hurt,attack, death};
    private State state = State.idle;

    public int health; // a varaible for the boss health

    public Animator anim; // a varialble for the animator

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector2.Distance(transform.position, target.position); // Calculates the distance between the Boss and the player

        //If you are close enough to the player it starts an attack timer
        //if the attack timer reaches 3 it loads the attack coroutine and resets the timer
        if (targetDistance < attackDistance)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > 3)
            {
                StartCoroutine(Attacks());
                attackTimer = 0;
            }
        }
       
        StateSwitch(); // Loads the StateSwitch function
        anim.SetInteger("state", (int)state); // Animates the boss depending on what state the boss is in

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If you collide with a bullet you load the take damage function
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage();
        }

    }
    //Deals 1 damage and changes the bosses state to hurt
    void TakeDamage()
    {
        state = State.hurt;
        health -= 1;
      //  health -= (int)Shooting.instace.DMG;
    }
    void Attack()
    {
        int random = Random.Range(0, 2);
        Vector2 myPos = new Vector2(attackPoint.position.x, attackPoint.position.y); //our current position is where our attack point is
        GameObject projectile = Instantiate(scrap[random], myPos, Quaternion.identity); //create our bullet
        Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
        projectile.GetComponent<Rigidbody2D>().velocity = -direction * launchForce; // Add a force to teh projectile
    }

    //Changes states to animate the boss
    public void StateSwitch()
    {
        if (health <= 0) // if health is lesser than 1 the state changes to death and the Die coroutine loads
        {
            state = State.death;
            StartCoroutine(Die());
        }
        else
        {
            state = State.idle; // if the boss doesnt do anything the bosses state is idle
        }
    }
    public IEnumerator Attacks()
    {
        //Changes the bosses state to the attacking state
        state = State.attack;

        yield return new WaitForSeconds(0.4f);
        //Loads the Attack function after .4 seconds
        Attack();
    }
    // Destroys the boss and loads the victoryscene
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.45f);
        Destroy(gameObject);
        SceneManager.LoadScene("Victory");
    }


}
