using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public GameObject Rock;
    // Start is called before the first frame update
    void Start()
    {
        Rock.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Rock.GetComponent<Rigidbody2D>().gravityScale = 10;
        }
    }
}
