using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayerMovement : MonoBehaviour
{


    //animator
    public Animator animator;
    public float horizontal;
    private float speed = 8f;
    private float jumpingPower = 8f;
    public Rigidbody2D rb;
    //checks to see if user can jump
    private bool canJump;
    //for flipping sprite when moving left
    private bool facingRight = true;

    private bool charMove = false;


    private EventInstance playerMoveSound;

    private void Start(){
        playerMoveSound = AudioManager.Instance.CreateEventInstance(FMODevents.Instance.moveSound);
    }

    private void UpdateSound(){
        if (rb.velocity.x !=0){
            PLAYBACK_STATE playbackState;
            playerMoveSound.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED)){
                playerMoveSound.start();
            }
        }
        else{
            playerMoveSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Gets User input and checks to see if the User can Jump
        if(Input.GetButtonDown("Jump") && !canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            AudioManager.Instance.PlayOneShot(FMODevents.Instance.jumpSound,this.transform.position);
            canJump = true;
            
        }
        //checks to see where the user is facing
        if (horizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            if (charMove == false){
                
                charMove = true;
            }

        }
        if (horizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            if (charMove == false){
                
                charMove = true;
            }
        }
        if (horizontal < 0 && !facingRight)
        {
            flipping();
        }
        if (horizontal < 0 && facingRight)
        {
            flipping();
        }
        if (horizontal == 0 && charMove == true){
            
            charMove = false;
        }

    }
    private void FixedUpdate()
    {
        //Movement speed of sprite
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        UpdateSound();
    }
 
    private void OnCollisionEnter2D(Collision2D ground)
    {   
        //checks to see if sprite is on the tag "Ground"
        if(ground.gameObject.CompareTag("Ground"))
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
