using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public Transform target;

    public GameObject [] scrap;
    public Transform attackPoint;
    public int launchForce;
    float attackTimer;

    private enum State { idle, hurt,attack, death};
    private State state = State.idle;

    public int health;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        attackTimer += Time.deltaTime;
        if(attackTimer > 3)
        {
            StartCoroutine(Attacks());
            attackTimer = 0;
        }
       
        StateSwitch();
        anim.SetInteger("state", (int)state);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage();
        }

    }
    void TakeDamage()
    {
        state = State.hurt;
        health -= 1;
    }
    void Attack()
    {
        int random = Random.Range(0, 2);
        Vector2 myPos = new Vector2(attackPoint.position.x, attackPoint.position.y); //our curr position is where our muzzle points
        GameObject projectile = Instantiate(scrap[random], myPos, Quaternion.identity); //create our bullet
        Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
        projectile.GetComponent<Rigidbody2D>().velocity = -direction * launchForce;
    }
    public void StateSwitch()
    {
        if (health <= 0)
        {
            health = 0;
            state = State.death;
            StartCoroutine(Die());
        }
        else
        {
            state = State.idle;
        }
    }
    public IEnumerator Attacks()
    {
        state = State.attack;
        yield return new WaitForSeconds(0.4f);
        Attack();
    }
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.45f);
        Destroy(gameObject);
        SceneManager.LoadScene("Victory");
    }


}
