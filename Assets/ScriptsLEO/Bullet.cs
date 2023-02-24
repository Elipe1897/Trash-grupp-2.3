using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    public ParticleSystem ps;
    public float aliveTime;
    public void Update()
    {
        instance = this;
        aliveTime += Time.deltaTime;
        if(aliveTime > 2.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Instantiate(ps,collision.transform.position, Quaternion.identity);
            CameraShake.instance.Shake();
            Destroy(gameObject);
        }
    }
}
