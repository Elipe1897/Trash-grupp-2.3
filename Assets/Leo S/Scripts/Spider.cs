using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    public Transform target;

    private bool isAttacking;

    public int health;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

    }

    private void Update()
    {
        if(isFacingRight())
        {
            //move right
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            //move left
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
        float targetDistance = Vector2.Distance(rb.position, target.position);
        if (targetDistance <= 3.5f && isAttacking == false)
        {
            moveSpeed = 0;
            isAttacking = true;
            StartCoroutine(Attack());            
        }
        else if (targetDistance >= 3.6f)
        {
            moveSpeed = 2;
            isAttacking = false;
        }
        if (health == 0)
        {
            StartCoroutine(Die());
        }
    }

    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            TakeDamage();
        }
    }
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(.4f);
        EnemySpawn.instance.killCount++;
        WaveSystem.instance.EnemyKilled();
        Destroy(gameObject);
    }
    void TakeDamage()
    {
        health -= 1;
    }
    public IEnumerator Attack()
    {
        if (isAttacking == true)
        {
            yield return new WaitForSeconds(2.3f);
            Health.instance.TakeDamage();
            isAttacking = false;
        }
    }

}