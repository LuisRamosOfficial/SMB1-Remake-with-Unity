using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private float velocity;
    private Transform Transform;

    // Booleans

    bool isRunning;
    bool isJumping;

    public Player(Rigidbody2D rigid, Animator anim, SpriteRenderer sprite, float Velocity)
    {
        this.rb = rigid;
        this.animator = anim;
        this.velocity = Velocity;
        this.sprite = sprite;
        this.Transform = this.transform;

    }


    public void Walk(String key)
    {
        
    }



}