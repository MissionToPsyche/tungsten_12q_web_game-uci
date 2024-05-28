using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalItems;
    public CollectionSystem collectionSystem;
    public LevelCompleteScreen LevelCompleteScreen;
    // Start is called before the first frame update
    public void LevelComplete()
    {
        //Opens Level Complete Canvas
        LevelCompleteScreen.Setup();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //If triggers an object with the tag level complete then open Level Complete canvas
        if(trigger.gameObject.CompareTag("Level Complete"))
        {
            //if (collectionSystem.counter == totalItems)
            //{
                LevelComplete();
            //}
        }
        
    }
}
