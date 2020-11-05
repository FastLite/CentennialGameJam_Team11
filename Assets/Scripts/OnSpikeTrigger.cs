﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpikeTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            gm.GameOver();
        }
    }
}
