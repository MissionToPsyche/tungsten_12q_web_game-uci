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
    private bool speedBuff = false;
    private float speedTimer = 10;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //Gets User input and checks to see if the User can Jump
        if(Input.GetButtonDown("Jump") && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canJump = true;
        }
        //checks speed buffs
        if(speedBuff)
        {
            //timer for speed buff
            speedTimer -= Time.deltaTime;
            if(speedTimer < 3)
            {
                speed = 8f;
                speedTimer = 10;
                speedBuff = false;

            }
        }

        
    }
    private void FixedUpdate()
    {
        //Movement speed of sprite
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D speedbuff)
    {
        //if colliding with speedbuff then it speedbuff = true
        if(speedbuff.gameObject.CompareTag("SpeedBuff"))
        {
            speedBuff = true;
            speed = 12f;

            Destroy(speedbuff.gameObject);
        }
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
