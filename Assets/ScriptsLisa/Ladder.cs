using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;       //variabel f�r att kunna r�ra sig vertikalt -Lisa     
    private float speed = 8f;     //variabel f�r speed -Lisa
    private bool isLadder;          //variabel f�r att kunna se om man �r vid en stege -Lisa
    private bool isClimbing;      //variabel f�r att se om man redan kl�ttrar -Lisa
    

    [SerializeField] private Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
          
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;

        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
           
        }
    }
}
