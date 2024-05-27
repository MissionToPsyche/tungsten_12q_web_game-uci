using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRock : MonoBehaviour
{
    public int x;
    public int y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Rolling Rock"))
        {
            collision.gameObject.GetComponent<Transform>().position = new Vector3(x, y, 0);
        }
    }
}
