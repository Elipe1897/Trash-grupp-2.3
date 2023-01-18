using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapDestroy : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")

        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            ScoreController.instance.AddSCrap(1);
        }
    }

}
