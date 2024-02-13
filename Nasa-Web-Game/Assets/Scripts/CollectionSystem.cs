using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSystem : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("Item1"))
        {
            Destroy(item.gameObject);
        }
    }
}
