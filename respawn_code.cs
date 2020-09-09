﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_code : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawn;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawn.transform.position;
    }
}
