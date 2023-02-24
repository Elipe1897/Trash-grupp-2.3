using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    //Leo S
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if bullet collide with enemy the bullet gets destroyed
        if(collision.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
