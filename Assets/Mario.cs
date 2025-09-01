using UnityEngine;

class Eue
{
    private Rigidbody2D physics;
    private Animator animation;
    private SpriteRenderer sprite;
} 





public class Mario : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public Animator anim;
    public SpriteRenderer sprite;
    public float velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!anim.GetBool("isJumping"))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                sprite.flipX = true;
                anim.SetBool("isRunning", true);
                myRigidBody.linearVelocity = Vector2.left * velocity;
            }


            else if (Input.GetKey(KeyCode.RightArrow))
            {
                sprite.flipX = false;
                anim.SetBool("isRunning", true);
                myRigidBody.linearVelocity = Vector2.right * velocity;
            }
            else
            {
                anim.SetBool("isRunning", false);
            }


        }



        if (Input.GetKey(KeyCode.UpArrow) && !anim.GetBool("isJumping"))
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
}
