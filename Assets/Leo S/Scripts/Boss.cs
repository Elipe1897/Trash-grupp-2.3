using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("state", (int)state);

        attackTimer += Time.deltaTime;
        if(attackTimer > 3)
        {
            state = State.attack;
            StartCoroutine(Attacks());
            attackTimer = 0;
        }
        if (health <= 0)
        {
            state = State.death;
        }
        StateSwitch();
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
    void Attack()
    {
        int random = Random.Range(0, 2);
        Vector2 myPos = new Vector2(attackPoint.position.x, attackPoint.position.y); //our curr position is where our muzzle points
        GameObject projectile = Instantiate(scrap[random], myPos, Quaternion.identity); //create our bullet
        Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
        projectile.GetComponent<Rigidbody2D>().velocity = -direction * launchForce;
    }
    private void StateSwitch()
    {
        state = State.idle;
    }
    public IEnumerator Attacks()
    {
        yield return new WaitForSeconds(0.4f);
        Attack();
    }


}
