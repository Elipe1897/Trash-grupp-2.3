using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    public static Randomize instance;

    [SerializeField]
    GameObject[] objects;

    float timer = 0;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Instantiate(objects[Random.Range(0, objects.Length)], transform.position, Quaternion.identity);
            timer = 0;
        }
        
    }
}
