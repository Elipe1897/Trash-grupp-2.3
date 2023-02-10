using UnityEngine;

public class Spider : MonoBehaviour
{
    public static Spider instance;
    private float currentHealth;
    private float minHealth;


    public BoxCollider2D collider2d;
    float speed = 2f;
    float chaseSpeed = 2.5f;

    float minimumDistance;
    float maximumDistance;

    [Header("Transforms")]
    public Transform groundCheck;
    public Transform target;

    Rigidbody2D rb;

    [Header("Layer masks")]
    public LayerMask GroundLayer;
    public LayerMask WallLayer;



    bool isFacingRight = true;

    float attackPlayer;


    RaycastHit2D hit;

    public Animator animator;

    float attackTimer;


    private void Start()
    {
        instance = this;

        minHealth = 0;
        currentHealth = 100;

        maximumDistance = 8f;
        minimumDistance = 1f;
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, .6f, GroundLayer);
        Debug.DrawRay(groundCheck.position, -transform.up * .6f, Color.red);
        // If the player is to the right of the enemy and the enemy is facing left, or if the player is to the left of the enemy and the enemy is facing right, turn the enemy around


        if (currentHealth == minHealth)
        {
            Destroy(gameObject);
        }
        attackTimer += Time.deltaTime * 3;

        Vector2 direction = (target.position - transform.position.normalized);
        Vector2 force = direction * speed * Time.deltaTime;

        float targetDistance = Vector2.Distance(rb.position, target.position);

        if (targetDistance >= 3.5f)
        {
            attackTimer = 0;
        }
        if (attackTimer >= 1)
        {
            Attack();
            attackTimer = 0;
        }

        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(3.7f, 3.7f, 3.7f);
        }
        else if (force.x <= 0.01f)
        {
            transform.localScale = new Vector3(-3.7f, 3.7f, 3.7f);
        }
    }
    private void FixedUpdate()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= minHealth)
        {
            currentHealth = minHealth;
        }
    }

    void Attack()
    {
        Health.instance.TakeDamage();
    }
}