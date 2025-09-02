using UnityEngine;





public class Mario : MonoBehaviour
{
    private readonly GameSettings settings;
    public Rigidbody2D myRigidBody;
    public Animator anim;
    public SpriteRenderer sprite;
    public float maxvelocity = 3f;
    public float jump  = 11f;
    public float acceleration = 3f;
    public float currentSpeedX = 0;
    public float currentSpeedY;
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask whatIsGround; 
    


    void Start()
    {
        myRigidBody.gravityScale = 3;
        myRigidBody.freezeRotation = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKey(KeyCode.C)) maxvelocity = 5;
        else maxvelocity = 3;
        

        //? Jump
        if (grounded && Input.GetKey(KeyCode.X) && !anim.GetBool("isJumping"))
        {


            myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x, jump);
            anim.SetBool("isJumping", true);
            anim.SetBool("isTurning", false);
            anim.SetBool("isRunning", false);
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
    
    //? Movement
    
        if (Input.GetKey(KeyCode.LeftArrow))

        {
            currentSpeedX = Mathf.MoveTowards(currentSpeedX, -maxvelocity, anim.GetBool("isTurning") ? acceleration * Time.deltaTime* 3 :  acceleration * Time.deltaTime);
            sprite.flipX = true;
            if (!anim.GetBool("isJumping"))
            {

                if (currentSpeedX > 0)
                {
                    anim.SetBool("isTurning", true);
                    anim.SetBool("isRunning", true);

                }
                else
                {
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isTurning", false);
                }
            }
            myRigidBody.linearVelocity = new Vector2(1f * currentSpeedX, myRigidBody.linearVelocity.y);
        }


        else if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeedX = Mathf.MoveTowards(currentSpeedX, maxvelocity, anim.GetBool("isTurning") ? acceleration * Time.deltaTime* 3 :  acceleration * Time.deltaTime);
            sprite.flipX = false;

            if (!anim.GetBool("isJumping"))
            {

                if (currentSpeedX < 0)
                {
                    anim.SetBool("isTurning", true);
                    anim.SetBool("isRunning", true);
                }
                else
                {
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isTurning", false);
                }
            }
            myRigidBody.linearVelocity = new Vector2(1f * currentSpeedX, myRigidBody.linearVelocity.y);
        }
        else
        {
            currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0, acceleration * Time.deltaTime * 2);
            if (!anim.GetBool("isJumping"))
            {
                anim.SetBool("isTurning", false);
                anim.SetBool("isRunning", false);
            }
            myRigidBody.linearVelocity = new Vector2(currentSpeedX, myRigidBody.linearVelocity.y);
        }

        
    }
}
