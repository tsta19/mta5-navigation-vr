using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Teleportation : MonoBehaviour
{
    // Player Reference
    public GameObject player;

    // Teleport Reference
    public Transform teleportTarget;
    
    // Teleportation Booleans
    private bool teleportActive1;
    private bool teleportActive2;
    private bool teleportActive3;
    private bool teleportActive4;

    // Debug Boolean
    private bool showDebug = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.transform.position = teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 1. teleporter"); }
            teleportActive1 = false;
        }
        
        if (col.gameObject.CompareTag("Player") && !teleportActive1)
        {
            player.transform.position = teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 2. teleporter"); }
            teleportActive2 = false;
        }
        
        if (col.gameObject.CompareTag("Player") && !teleportActive1 && !teleportActive2)
        {
            player.transform.position = teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 3. teleporter"); }
            teleportActive3 = false;
        }
        
        if (col.gameObject.CompareTag("Player") && !teleportActive1 && !teleportActive2 && !teleportActive3)
        {
            player.transform.position = teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 4. teleporter"); }
            teleportActive4 = false;
        }
    }
}