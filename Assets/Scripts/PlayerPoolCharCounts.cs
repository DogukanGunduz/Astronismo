using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoolCharCounts : PlayerPool
{
    private void Awake()
    {
        PlayerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        AlienCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

    }

 }

  






