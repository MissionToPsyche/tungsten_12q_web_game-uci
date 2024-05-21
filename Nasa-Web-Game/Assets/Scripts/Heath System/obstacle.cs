using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] private float dmg;
    public PlayerMovement playerMovement;
    public Animator animator;
    private Coroutine routine;
    private void OnTriggerEnter2D(Collider2D unit){
        if (unit.tag == "Player") {

            if (routine == null)
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
    IEnumerator TakeDamage()
    {
        animator.SetBool("isHit", true);
        dmg = 0;
        yield return new WaitForSeconds(2f);
        animator.SetBool("isHit", false);
        dmg = 1;
        routine = null;

    }




}