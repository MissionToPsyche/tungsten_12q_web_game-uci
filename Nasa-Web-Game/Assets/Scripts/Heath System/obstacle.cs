using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] private float dmg;
    public PlayerMovement playerMovement;
    public Animator animator;
    private Coroutine routine;

    private void OnTriggerEnter2D(Collider2D unit)
    {
        if (unit.tag == "Player")
        {


            if (routine == null)
            {

                if (CompareTag("Rolling Rock"))
                {
                    //if the velocity is high, then it will cause the player damage   
                    if(GetComponent<Rigidbody2D>().velocity.y < -1 || GetComponent<Rigidbody2D>().velocity.x < -1)
                    { 
                        playerMovement.KBCounter = playerMovement.KBTotalTime;
                        if (unit.transform.position.x <= transform.position.x)
                        {
                            playerMovement.KBfromRight = true;
                        }
                        if (unit.transform.position.x > transform.position.x)
                        {
                            playerMovement.KBfromRight = false;
                        }

                        unit.GetComponent<health>().takeDamage(dmg);
                        routine = StartCoroutine("TakeDamage");
                    }
                }
                else
                {

                    playerMovement.KBCounter = playerMovement.KBTotalTime;
                    if (unit.transform.position.x <= transform.position.x)
                    {
                        playerMovement.KBfromRight = true;
                    }
                    if (unit.transform.position.x > transform.position.x)
                    {
                        playerMovement.KBfromRight = false;
                    }

                    unit.GetComponent<health>().takeDamage(dmg);
                    routine = StartCoroutine("TakeDamage");
                }
            }
        }
    }
    IEnumerator TakeDamage()
    {   
        animator.SetBool("isHit", true);
        dmg = 0;
        Physics2D.IgnoreCollision(playerMovement.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreCollision(playerMovement.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        animator.SetBool("isHit", false);
        dmg = 1;
        routine = null;

    }




}