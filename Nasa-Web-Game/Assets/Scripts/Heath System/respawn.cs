using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private Transform curCheckpoint; //move current checkpoint into this parameter
    private health playerHealth;

    

    
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
            curCheckpoint = collision.transform;
            playerHealth.CheckpointUnlocked = true;
            collision.GetComponent<Collider>().enabled = false;
        }
    }

    void Update(){
        if (playerHealth.deathFlag == true && playerHealth.CheckpointUnlocked  == true){
            Debug.Log("CheckpointDeath");
            moveToCheckpoint();
        }
    }

}
