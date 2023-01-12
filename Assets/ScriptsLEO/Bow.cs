using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject[] Arrow;
    int Arrows;
    public float startSpeed;
    public float launchForce;
    public Transform shotPoint;
    public Animator animator;

    // Update is called once per frame
    private void Start()
    {
        launchForce = 0;

    }
    void Update()
    {

        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;
        if (Input.GetKey(KeyCode.Space))
        {
            launchForce += .016f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Arrows = 0;
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Arrows = 1;
        }

        //Bow animation
        if(launchForce == 0)
        {
            animator.SetBool("BowZero", true);
            animator.SetBool("BowSecond", false);
            animator.SetBool("BowFirst", false);
            animator.SetBool("BowThird", false);
        }
        else if(launchForce > 0 && launchForce <= 1)
        {
            animator.SetBool("BowFirst", true);
            animator.SetBool("BowSecond", false);
            animator.SetBool("BowThird", false);
            animator.SetBool("BowZero", false);
        }
        else if( launchForce >= .5f && launchForce <= 2)
        {
            animator.SetBool("BowSecond", true);
            animator.SetBool("BowThird", false);
            animator.SetBool("BowFirst", false);
            animator.SetBool("BowZero", false);
        }
        else if( launchForce > 2 && launchForce <= 3)
        {
            animator.SetBool("BowThird", true);
            animator.SetBool("BowSecond", false);
            animator.SetBool("BowFirst", false);
            animator.SetBool("BowZero", false);
        }
    }
    void Shoot()
    {
        if (launchForce >= 3)
        {
            launchForce = 3;
        }
        else if (launchForce <= .5f)
        {
            launchForce = 0.5f;
        }

            
        GameObject newArrow = Instantiate(Arrow[Arrows], shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * (launchForce * startSpeed);
        launchForce = 0;
    }
    
}