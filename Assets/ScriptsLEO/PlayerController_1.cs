using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_1 : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Moving")]
    [SerializeField, Range(0, 1)]
    float fHorizontalDampingBasic, fHorizontalDampingWhenStopping;

    [Header("Jumping")]
    public int jumpVelocity = 6;

    private float gravityScale = 1;
    private float fallGravityMultiplier = 1.8f;

    private float coyoteTimer = .15f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = .1f;
    private float jumpBufferCounter;

    [Header("isGrounded")]
    public BoxCollider2D boxCollider;

    [SerializeField]
    private LayerMask platformLayerMask;

    public Text ScrapsText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (IsGrounded()) { coyoteTimeCounter = coyoteTimer; }
        else { coyoteTimeCounter -= Time.deltaTime; }
        if (Input.GetKeyDown(KeyCode.W)) { jumpBufferCounter = jumpBufferTime; }
        else { jumpBufferCounter -= Time.deltaTime; }

        Jump();
    }
    private void FixedUpdate()
    {
        Move();
       if(rb.velocity.y < 0) { rb.gravityScale = gravityScale * fallGravityMultiplier; }
       else { rb.gravityScale = gravityScale; }
    }

    private void Move()
    {
        //Mathf.abs makes negative numbers positive
        //Mathf.abs takes one number and raises it to the power of another number

         float xVel = rb.velocity.x;
        xVel += Input.GetAxisRaw("Horizontal");
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))<.01f) //Checks if the player is slowing down 
            xVel *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f); // it dampens your speed when you stop moving so you stop faster
        else
            xVel *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f); // it dampens your speed so you accelerate slower when you are faster 
        rb.velocity = new Vector2(xVel, rb.velocity.y);

    }

    void Jump()
    {
        if (coyoteTimeCounter > 0 && jumpBufferCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            jumpBufferCounter = 0;
        }
        if(Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
            coyoteTimeCounter = 0;
        }
    }
    
    public bool IsGrounded()
    {
        float extraHeight = .1f;
         RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
   }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Scrap")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

            }

        }
    }
}
