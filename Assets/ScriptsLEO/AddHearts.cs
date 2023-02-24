using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHearts : MonoBehaviour
{

    //If the heart object would collide with the player then The instanse AddHealth in the Health script would be used and it would destroy the heart object - Leo N
    public void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.transform.tag == "Player")
        {
            Health.instance.AddHealth();
            Destroy(gameObject);
        }
            
    }
}
