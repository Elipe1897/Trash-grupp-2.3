using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : EnemyAI
{
    public Animator anim;

    public int health;


    private enum State { idle,hurt,death};
    private State state = State.idle;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        speed = 5;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        anim.SetInteger("state", (int)state);
        StateSwitch();
        if(health <= 0)
        {
            state = State.death;
        }
        Debug.Log((int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            state = State.hurt;
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        health -= 1;
    }

    private void StateSwitch()
    {
        state = State.idle;
    }
}
