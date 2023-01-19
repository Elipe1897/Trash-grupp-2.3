using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public static Health instance;
    public int maxHealth = 3;
    public int currentHealth;

    public GameObject Heart3;
    public GameObject Heart2;
    public GameObject Heart1;

    [SerializeField] private AudioSource damageSoundEffect; 

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
            
            //Destroy(gameObject);
            Destroy(Heart1);
            
            transform.position = new Vector3(20, -5, 0);
        }
        if (currentHealth == 2)              //ett hjärta försvinner när man tappar ett liv
        {

            Destroy(Heart3);
            
        }
        if (currentHealth == 1)              
        {
            
            Destroy(Heart2);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)    //om man nuddar en bullet så förlorar man ett liv-Lisa
    {
        if (collision.transform.tag == "Aj")
        {
            Health.instance.TakeDamage();
         
        }

        if (collision.transform.tag == "die")
        {
            
            damageSoundEffect.Play();
        }

    }

    
    public void TakeDamage()
    {
        currentHealth -= 1; // gör så att man förlorar liv-Lisa
    }

    
}
