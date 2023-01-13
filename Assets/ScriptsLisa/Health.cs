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
        instance = this; // It assigns itself as a instance.
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 3; // When the game starts your health is set to 3.
    }


    // Update is called once per frame
    void Update()
    {
        
        if (currentHealth == 0)
        {
            Destroy(gameObject);
            // transform.position = new Vector3(-20, 20, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Aj")
        {
            Health.instance.TakeDamage();
        }
    }
    public void TakeDamage()
    {
        currentHealth -= 1; // makes you lose health
    }


}
