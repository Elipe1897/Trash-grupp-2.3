using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem ps;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Instantiate(ps, collision.transform.position, Quaternion.identity);
            CameraShake.instance.Shake();
            Destroy(gameObject);
        }
    }
}
