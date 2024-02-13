using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CollectionSystem : MonoBehaviour
{
    public TMP_Text collectedAmount;
    private int counter;
    // Update is called once per frame
    void Update()
    {
        collectedAmount.text = counter.ToString();
    }
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("Item"))
        {
            counter++;
            Destroy(item.gameObject);
        }
    }
}
