using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //animator
    public Animator animator;
    public float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    //checks to see if user can jump
    private bool canJump;
    //for flipping sprite when moving left
    private bool facingRight = true;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KBfromRight;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        
        //Gets User input and checks to see if the User can Jump
        if(Input.GetButtonDown("Jump") && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canJump = true;
        }
        //checks to see where the user is facing
        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (horizontal < 0 && !facingRight)
        {
            flipping();
        }
        if (horizontal < 0 && facingRight)
        {
            flipping();
        }

    }
    private void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        else
        {
            if (KBfromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KBfromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
        //Movement speed of sprite
        
    }

    private Collider2D getComponent<T>()
    {
        throw new NotImplementedException();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if sprite is on the tag "Ground"
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Moveable Rock"))
        {
            canJump = false;
        }
    }
    
    void flipping()
    {
        Vector3 scale = gameObject.transform.localScale;
        scale *= -1;
        gameObject.transform.localScale = scale;
        facingRight = !facingRight;
    }
}
