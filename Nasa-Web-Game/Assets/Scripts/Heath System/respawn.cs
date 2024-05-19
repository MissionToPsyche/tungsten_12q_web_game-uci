using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{   
    public Sprite sprite;
    private Transform curCheckpoint; //move current checkpoint into this parameter
    private health playerHealth;
    
    private checkpointOrder checkOrder;

    private bool firstCheck;

    

    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<health>();
    }

    // Update is called once per frame
    void moveToCheckpoint()
    {
        transform.position = curCheckpoint.position; //Move Player to Checkpoint
        playerHealth.revivePlayer(); // Will restore stats like health back to player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoints")
        {
            playerHealth.CheckpointUnlocked = true;
            if (firstCheck == false){
                checkOrder = collision.gameObject.GetComponent<checkpointOrder>();
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = sprite; 
                curCheckpoint = collision.transform;
                firstCheck = true;
            }
            else{
            
                if (collision.gameObject.GetComponent<checkpointOrder>().checkpointNum > checkOrder.checkpointNum){
                    curCheckpoint = collision.transform;
                }
            }
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }

    void Update(){
        if (playerHealth.deathFlag == true && playerHealth.CheckpointUnlocked  == true){
            Debug.Log("CheckpointDeath");
            moveToCheckpoint();
        }
    }

}
