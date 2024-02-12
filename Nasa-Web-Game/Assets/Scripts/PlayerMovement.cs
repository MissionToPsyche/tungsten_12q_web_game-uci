using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    private bool canJump;
    public Rigidbody2D rb;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canJump = true;
        }
        

        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        { 
            canJump = false;
        }
    }

}
