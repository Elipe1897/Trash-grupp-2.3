using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController_1 : MonoBehaviour
{
    public static PlayerController_1 instance;  
    [SerializeField] private AudioSource playerdieSoundEffect;
    [SerializeField] private AudioSource coinSoundEffect;
    [SerializeField] private AudioSource backgroundSoundEffect;
    [SerializeField] private AudioSource hoppSoundEffect;

    // Lisa ^^
    private enum State { idle,run, jump, hurt, death };// leo s 
    private State state = State.idle; // leo s 

    public Animator anim; // Leo s 

    public GameObject GFX; // Leo s

    Health health; // lisa

    Rigidbody2D rb; //A varible for rigibody - Elias 
    [Header("Moving")] // Head titel for the serializedfield - Elias
    [SerializeField, Range(0, 1)]
    float fHorizontalDampingBasic, fHorizontalDampingWhenStopping; // Varibles for the friction when moving - Elias 

    [Header("Jumping")]
    public int jumpVelocity = 6; 

    private float gravityScale = 1;
    private float fallGravityMultiplier = 1.8f;

    private float coyoteTimer = .15f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = .1f;
    private float jumpBufferCounter;

    [Header("isGrounded")]
    public PolygonCollider2D boxCollider;

    [SerializeField]
    private LayerMask platformLayerMask;

    public Text ScrapsText;

    public bool TouchBin;
    public bool TouchScrap;

 // Varibles ^^ - Elias

    public GameObject ExtraHeart1; // Leo n
    public GameObject ExtraHeart2; // Leo n 
    public GameObject ExtraHeart3; // Leo n 

    public GameObject PopUpText1;
    public GameObject PopUpText2;
    public GameObject PopUpText3;
    public GameObject PopUpText4;
    public GameObject PopUpText5;
    public GameObject PopUpText6;
    public GameObject PopUpText7;
    public GameObject PopUpText8;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Sets the rigibody component in the rb varible - Elias 
        health = GetComponent<Health>(); // nån
        instance = this;
    }
    private void Update()
    {
        // leo s
        StateSwitch();
        anim.SetInteger("states", (int)state);

        /*checks if isGrounded funktion is true then if so its sets coyoteTimecounter to coyoteTimer which means after you leave 
         The ground you have a small window to jump. But else it sets coyoteTimeCounter to -= time.deltatime.
         then i checks if W is pressed and if so it checks jumpBufferCounter = jumpBufferTime basically if you can jump or not and if not
         it counts down jumpbuffercounter with -= time.deltatime  - Elias */
        if (IsGrounded()) { coyoteTimeCounter = coyoteTimer; }
        else { coyoteTimeCounter -= Time.deltaTime; }
        if (Input.GetKeyDown(KeyCode.W)) { jumpBufferCounter = jumpBufferTime; }
        else { jumpBufferCounter -= Time.deltaTime; }
        
        Jump(); // runs the jump funktion - Elias

      
        Flip(); // runs the Flip funktion - Elias

        if (TouchBin == true) // checks if Touchbin is true and then checks if key E is pressed down and if so run AddPoint funktion and coin sound - Elias
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                coinSoundEffect.Play();
                ScoreManagement.instance.AddPoint(ScoreManagement.instance.Scrap);
                
            }
        }
        if (TouchScrap == true) // Checks if touchScrap is true of if its true its runs addScrap funktion - Elias
        {
            ScoreManagement.instance.AddSCrap();
            
        }
    }
    private void FixedUpdate()
    {
        Move(); //Runs the move funktion - Elias
        // if rb.velocity.y is less than zero it sets the rb.gravityscale of the rigidbody to gravityScale variable times the
        // fallGravityMultiplier constant. - Elias
        //then if rb.gravityscale.y is more than 0 its sets  rb.gravityScale = gravityScale - Elias
        if (rb.velocity.y < 0) { rb.gravityScale = gravityScale * fallGravityMultiplier; }
        else { rb.gravityScale = gravityScale; }
    }

    private void Move()
    {
        //Mathf.abs makes negative numbers positive  - Elias
        //Mathf.abs takes one number and raises it to the power of another number - Elias

         float xVel = rb.velocity.x;
        xVel += Input.GetAxisRaw("Horizontal");
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal"))<.01f) //Checks if the player is slowing down - Elias
            xVel *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f); // it dampens your speed when you stop moving so you stop faster - Elias
        else
            xVel *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f); // it dampens your speed so you accelerate slower when you are faster - Elias
        rb.velocity = new Vector2(xVel, rb.velocity.y);
    }
    void Flip() // this changes the direktion your character is pointed to - Elias
    {
        if (rb.velocity.x >= 0.1)
        {
            GFX.transform.localScale = new Vector3(3.7f,3.7f,3.7f);
        }
        else if (rb.velocity.x <= -0.1)
        {
            GFX.transform.localScale = new Vector3(-3.7f, 3.7f, 3.7f);
        }
    }
    void Jump()
    {
        //checks if coyoteTimeCounter and jumpBufferCounter are greater than 0 and if both are it sets the vertical velocity (y-axis) of the rigidbody component rb to jumpVelocity
        //and therfore initiating a jump then it sets the jumpBufferCounter to 0 - Elias
        if (coyoteTimeCounter > 0 && jumpBufferCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            jumpBufferCounter = 0;
        }
        // When button W and the rb varibles velocity on the y.axis is bigger than zero than its velocity on the x axis remains the same
        // and velocity on the y axis is set to half of its orignal speed  - Elias
        if(Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0)
        {
            hoppSoundEffect.Play(); // lisa
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2);
            coyoteTimeCounter = 0;
        }
    }
    
    public bool IsGrounded() // First it sets extraHeight varible to 0.1 to be able to detect coliders slighty over the raycast
    {                        // basiclly checking if a 2D box collider attached to an object is currently touching a platform layer in the scene 
                             // and lastly if raycastHit.colider is != null then it hit something oterwise - Elias
        float extraHeight = .1f;
         RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
   }
    public void OnTriggerStay2D(Collider2D collision) // Sets TouchBin and Touchscrap true if the object collides with de right tag - Elias
    {
        if (collision.transform.tag == "Bin")
        {
            TouchBin = true;
        }

        if (collision.transform.tag == "Scrap")
        {
            TouchScrap = true;
        }

        //If the player comes in the specific "Soptunna" then the specific text for that "Soptunna" will be set active - Leo N
        if(collision.gameObject.name == "Soptunna1")
        {
            PopUpText1.SetActive(true);
        }
        if (collision.gameObject.name == "Soptunna2")
        {
            PopUpText2.SetActive(true);
        }
        if (collision.gameObject.name == "Soptunna3")
        {
            PopUpText3.SetActive(true);
        }
        if (collision.gameObject.name == "Soptunna4")
        {
            PopUpText4.SetActive(true);
        }
         if (collision.gameObject.name == "Soptunna5")
        {
            PopUpText5.SetActive(true);
        }
        if (collision.gameObject.name == "Soptunna6")
        {
            PopUpText6.SetActive(true);
        }
        if (collision.gameObject.name == "Soptunna7")
        {
            PopUpText7.SetActive(true);
        }
        if (collision.gameObject.name == "Soptunna8")
        {
            PopUpText8.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // Sets TouchBin and Touchscrap false if the object collides with de right tag - Elias
    {
        if (collision.transform.tag == "Bin")
        {
            TouchBin = false;
        }

        if (collision.transform.tag == "Scrap")
        {
            TouchScrap = false;
        }

        //If the player exit in the specific "Soptunna" then the specific text for that "Soptunna" will be turned off - Leo N
        if (collision.gameObject.name == "Soptunna1")
        {
            PopUpText1.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna2")
        {
            PopUpText2.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna3")
        {
            PopUpText3.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna4")
        {
            PopUpText4.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna5")
        {
            PopUpText5.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna6")
        {
            PopUpText6.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna7")
        {
            PopUpText7.SetActive(false);
        }
         if (collision.gameObject.name == "Soptunna8")
        {
            PopUpText8.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // nån
    {
        if (collision.transform.tag == "Aj")
        { 
          Health.instance.TakeDamage();
         
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // nån
    {
        if(collision.transform.tag == "Enemy"|| collision.transform.tag =="Aj")
        {
            playerdieSoundEffect.Play();
            state = State.hurt;
        }
    }
    private void StateSwitch() // Leo s 
    {
        if (health.currentHealth > 0)
        {
            if (rb.velocity.x >= 0.1)
            {
                state = State.run;
            }
            else if (rb.velocity.x <= -0.1)
            {
                state = State.run;
            }
            else
            {
                state = State.idle;
            }
        }
        else if (health.currentHealth == 0)
        {
            
            state = State.death;
            StartCoroutine(Die());
        }
    }
    public IEnumerator Die() // nån
    {
        
    
        yield return new WaitForSeconds(.75f);
       // transform.position = new Vector3(-85, -5, 0);
       
        SceneManager.LoadScene("Death");
    }

}
