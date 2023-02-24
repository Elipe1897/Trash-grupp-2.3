using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Leo s
public class Skjuta : MonoBehaviour
{
    public GameObject scrap;// variable ´for the scrap
    public Transform attackPoint; // variable for where the scrap gets shot from
    public int launchForce; // variable for how fast the scrap will be shot

    // Update is called once per frame
    void Update()
    {
        // if you press the key e you trigger the attack function
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }
    public void Attack()
    {
        Vector2 myPos = new Vector2(attackPoint.position.x, attackPoint.position.y); //our curr position is where our muzzle points
        GameObject projectile = Instantiate(scrap, myPos, Quaternion.identity); //create our bullet
        Vector2 direction = myPos - (Vector2)Input.mousePosition; //get the direction to the target
        projectile.GetComponent<Rigidbody2D>().velocity = -direction * launchForce; // adds force to the projectile
    }
}
