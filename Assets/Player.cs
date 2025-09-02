using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player
{
    // Attributes
    private Rigidbody2D rb;
    public GameSettings settings;
    private Animator animator;
    private SpriteRenderer sprite;
    private float velocity;
    private Transform Transform;

    // Booleans

    private bool running;
    private bool jumping;
    private float gravity;
    public Player(Rigidbody2D rigid, Animator anim, SpriteRenderer sprite, float Velocity)
    {
        this.rb = rigid;
        this.animator = anim;
        this.velocity = Velocity;
        this.sprite = sprite;

        running = false;
        jumping = false;
        gravity = settings.gravity;
        
    }

    public bool Running() => running;
    

    public bool Jumping() => jumping;

    public bool IsGrounded(Transform groundCheck, float checkRadius, LayerMask theGround) => Physics2D.OverlapCircle(groundCheck.position, checkRadius, theGround);

    public void Walk(String key)
    {
        switch (key)
        {

            case "right":
                
                break;


            case "left":

                break;
        
        }
    }



}
