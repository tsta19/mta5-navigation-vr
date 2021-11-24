using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Teleportation : MonoBehaviour
{
    // Player Reference
    public GameObject player;

    // Teleport Reference
    public Transform teleportTarget1;
    public Transform teleportTarget2;
    public Transform teleportTarget3;
    public Transform teleportTarget4;
    public Transform teleportTarget5;
    

    // Debug Boolean
    private bool showDebug = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && WayPointChecker.MazeID == 1)
        {
            player.transform.position = teleportTarget1.transform.position;
            if (showDebug) { print("You have collided with the 1. teleporter"); }
        }
        
        if (col.gameObject.CompareTag("Player") && WayPointChecker.MazeID == 2)
        {
            player.transform.position = teleportTarget2.transform.position;
            if (showDebug) { print("You have collided with the 2. teleporter"); }
        }
        
        if (col.gameObject.CompareTag("Player") && WayPointChecker.MazeID == 3)
        {
            player.transform.position = teleportTarget3.transform.position;
            if (showDebug) { print("You have collided with the 3. teleporter"); }
        }
        
        if (col.gameObject.CompareTag("Player") && WayPointChecker.MazeID == 4)
        {
            player.transform.position = teleportTarget4.transform.position;
            if (showDebug) { print("You have collided with the 4. teleporter"); }
        }
        
        if (col.gameObject.CompareTag("Player") && WayPointChecker.MazeID == 5)
        {
            player.transform.position = teleportTarget5.transform.position;
            if (showDebug) { print("You have collided with the 5. teleporter"); }
        }
    }
}