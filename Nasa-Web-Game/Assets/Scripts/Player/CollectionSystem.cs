using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CollectionSystem : MonoBehaviour
{
    public TMP_Text collectedAmount;
    public int counter;
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
            AudioManager.Instance.PlayOneShot(FMODevents.Instance.collectSFX,this.transform.position);
            Destroy(item.gameObject);
        }
    }
}
