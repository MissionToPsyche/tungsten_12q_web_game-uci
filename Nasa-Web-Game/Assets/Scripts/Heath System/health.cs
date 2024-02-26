using UnityEngine;
using UnityEngine.AI;

public class health : MonoBehaviour
{
    [SerializeField]private float startHealth;
    private float maxHealth;
    public float curHealth { get; private set;}

    public bool deathFlag;

    public bool CheckpointUnlocked;

    public Vector3 respawnPoint;

    

    private void Awake()
    {
        CheckpointUnlocked = false;
        curHealth = startHealth;
        respawnPoint = transform.position;
    }

    public void takeDamage(float dmg)
    {
        curHealth -= dmg;
        //the below will be used for damage animations if we do that
        if (curHealth > 0) {
            //dmg flash
        }
        else{
            //respawn

            deathFlag = true;
            Debug.Log("death");
            if (CheckpointUnlocked == false)
            {
                Debug.Log("noCheckDeath");
                revivePlayer();
                transform.position = respawnPoint;  
            }
        }
    }

    public void addHealth(float val)
    {
        curHealth += val;
    }

    public void revivePlayer()
    {
        addHealth(startHealth);
        deathFlag = false;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            takeDamage(1);
        }
    }

}
