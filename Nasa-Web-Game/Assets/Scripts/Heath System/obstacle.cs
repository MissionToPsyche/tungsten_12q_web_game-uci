using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] private float dmg;
    public PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D unit){
        if (unit.tag == "Player") {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(unit.transform.position.x <= transform.position.x)
            {
                playerMovement.KBfromRight = true;
            }
            if(unit.transform.position.x > transform.position.x)
            {
                playerMovement.KBfromRight = false;
            }
            unit.GetComponent<health>().takeDamage(dmg);
        }
    }
    IEnumerable invulnerability()
    {
        Physics2D.IgnoreLayerCollision(2, 3, true);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(2, 3, false);
    }




}