using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapDestroy : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Sets the rigibody component in the rb varible - Elias 
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    private void OnTriggerEnter2D(Collider2D collision) // on collision enter and when the tag is equal to ground its sets rb velocity to zero and then 
       // and rb.isKinematics component it set to true
    {
        if (collision.transform.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision) // when collison stay and when collison tag is Player the gameobject destroys and it runs the ADDScrap funktion
                                                      // And then returs the value of the funktion. - Elias
    {
         if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            ScoreManagement.instance.AddSCrap();
            return;
        }
    }
  

}
