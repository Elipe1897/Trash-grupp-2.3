using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Leo S
public class DestroyBossSrap : MonoBehaviour
{
    //Destroys the scraps when they collide with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    //Destroys the scraps when they collide with the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
