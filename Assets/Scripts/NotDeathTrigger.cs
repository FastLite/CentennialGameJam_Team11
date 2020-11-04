using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDeathTrigger : MonoBehaviour
{
public enum MonsterType
{
    MonsterA,
    MonsterB,
    MonsterC
}


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<GhostSpawner>().GoingGhost();
            other.gameObject.GetComponent<GhostSpawner>().GhostExits = true; 
        }
    }
}
