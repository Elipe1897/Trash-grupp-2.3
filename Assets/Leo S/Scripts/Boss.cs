using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform target;

    public GameObject scrap;
    public Transform attackPoint;
    public int launchForce;
    float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer > 3)
        {
            Attack();
            attackTimer = 0;
        }
    }
    void Attack()
    {
        Vector2 myPos = new Vector2(attackPoint.position.x, attackPoint.position.y); //our curr position is where our muzzle points
        GameObject projectile = Instantiate(scrap, myPos, Quaternion.identity); //create our bullet
        Vector2 direction = myPos - (Vector2)target.position; //get the direction to the target
        projectile.GetComponent<Rigidbody2D>().velocity = -direction * launchForce;
    }
}
