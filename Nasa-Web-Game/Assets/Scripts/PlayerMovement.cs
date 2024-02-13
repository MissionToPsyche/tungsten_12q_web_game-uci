using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    public Rigidbody2D rb;
    private bool canJump;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //Gets User input and checks to see if the User can Jump
        if(Input.GetButtonDown("Jump") && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canJump = true;
        }

        
    }
    private void FixedUpdate()
    {
        //Movement speed of sprite
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D ground)
    {   
        //checks to see if sprite is on the tag "Ground"
        if(ground.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

}
