using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    public SpriteRenderer caveBg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnAnimatorIK(int layerIndex)
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(caveBg.GetComponent<SpriteRenderer>().sortingOrder == -1)
            {
                caveBg.GetComponent<SpriteRenderer>().sortingOrder = -4;
            }
            else if(caveBg.GetComponent<SpriteRenderer>().sortingOrder == -4)
            {
                caveBg.GetComponent<SpriteRenderer>().sortingOrder = -1;
            }

        }
    }
}
