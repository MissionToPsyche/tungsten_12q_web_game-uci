using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelCompleteScreen: MonoBehaviour
{
    private void Start()
    {
       //Starts canvas closed
       gameObject.SetActive(false);
    }
    public void Setup()
    {
        //opens Canvas
        gameObject.SetActive(true);
    }
}
