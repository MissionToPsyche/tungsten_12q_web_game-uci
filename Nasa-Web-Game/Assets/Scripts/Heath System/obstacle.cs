using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] private float dmg;
    private void OnTriggerEnter2D(Collider2D unit){
        if (unit.tag == "Player") {
            unit.GetComponent<health>().takeDamage(dmg);
        }
    }



}