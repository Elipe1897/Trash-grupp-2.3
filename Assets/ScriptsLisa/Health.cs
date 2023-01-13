using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static Health instance;
    public int maxHealth = 3;
    public int currentHealth;


    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 3; //man börjar med 3 liv-Lisa
    }


    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth == 0)              //När man har 0 liv kvar så dör man-Lisa
        {
            Destroy(gameObject);  
            // transform.position = new Vector3(-20, 20, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)    //om man nuddar en bullet så förlorar man ett liv-Lisa
    {
        if (collision.transform.tag == "Aj")
        {
            Health.instance.TakeDamage();
        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1; // gör så att man förlorar liv-Lisa
    }


}
