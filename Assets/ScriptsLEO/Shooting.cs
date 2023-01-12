using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float DMG = 5;

    public GameObject Bullet;
    public GameObject FireEffect;
    public void Start()
    {

    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Bullet, new Vector3(transform.position.x + 1.35f, transform.position.y -0.05f), Quaternion.identity);
            Debug.Log("FIRE!");
            Instantiate(FireEffect, transform.position, Quaternion.identity);
            Debug.Log("Effect!");
            StartCoroutine(RecoilTrue());
        }
    }

    public IEnumerator RecoilTrue()
    {
        transform.position += new Vector3(-20, 0) * Time.deltaTime;
        yield return new WaitForSeconds(0.1f);
        transform.position += new Vector3(20, 0) * Time.deltaTime;
    }
}
