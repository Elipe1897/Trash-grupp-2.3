using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 12f;

    public Transform target;

    public Vector2 minPos;
    public Vector2 maxPos;



    private void Update()
    {
        if (transform.position != target.position)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10);

            newPos.x = Mathf.Clamp(newPos.x, minPos.x, maxPos.x);
            newPos.y = Mathf.Clamp(newPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        }

    }
}