using UnityEngine;

public class FollowScript : MonoBehaviour
{
    // The player object that the object will follow
    public Transform player;

    // The speed at which the object will move
    public float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the object and the player
        float distance = Vector2.Distance(transform.position, player.position);

        // If the distance is greater than 0, move towards the player
        if (distance > 0)
        {
            // Calculate the direction to move in
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the object towards the player
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
}
