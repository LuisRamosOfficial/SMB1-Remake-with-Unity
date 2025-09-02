using UnityEngine;





public class Mario : MonoBehaviour
{

    private readonly GameSettings settings;
    public Rigidbody2D myRigidBody;
    public Animator anim;
    public SpriteRenderer sprite;
    public float velocity;
    public float jump;

    public Transform groundCheck;       // Empty GameObject at the player's feet
    public float checkRadius = 0.2f;    // Size of the circle

    public LayerMask whatIsGround; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody.freezeRotation = true; // prevents any rotation
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        if (grounded && Input.GetKey(KeyCode.X) && !anim.GetBool("isJumping"))
        {
            myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x, jump);
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", true);
        }

        if (grounded && !Input.GetKey(KeyCode.X) && anim.GetBool("isJumping"))
        {
            myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x, 0f);
            anim.SetBool("isJumping", false);
        }

        if (grounded && Input.GetKey(KeyCode.X) && anim.GetBool("isJumping"))
        {
            myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x, jump);
        }
    
    
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sprite.flipX = true;
            if (!anim.GetBool("isJumping"))
            {
                
            anim.SetBool("isRunning", true);
            }
            myRigidBody.linearVelocity = new Vector2(-1f * velocity, myRigidBody.linearVelocity.y);
        }


        else if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite.flipX = false;
            if (!anim.GetBool("isJumping"))
            {
            anim.SetBool("isRunning", true);
            }
            myRigidBody.linearVelocity = new Vector2(1f * velocity, myRigidBody.linearVelocity.y);
        }
        else
        {
            if (!anim.GetBool("isJumping"))
            {
                
            anim.SetBool("isRunning", false);
            }
            myRigidBody.linearVelocity = new Vector2(0f, myRigidBody.linearVelocity.y);
        }


        



        
    }
}
