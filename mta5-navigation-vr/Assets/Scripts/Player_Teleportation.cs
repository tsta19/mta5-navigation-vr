using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Teleportation : MonoBehaviour
{
    // Get mazeID
    int mazeID;
    // Player Reference
    public GameObject player;

    // Teleport Reference
    public Transform teleportTarget1;
    public Transform teleportTarget2;
    public Transform teleportTarget3;
    public Transform teleportTarget4;
    public Transform teleportTarget5;
    

    // Debug Boolean
    private bool showDebug = true;

    private void OnTriggerEnter(Collider col)
    {
        mazeID = WayPointChecker.MazeID;
        if (mazeID == 0)
        {
            player.transform.position = teleportTarget1.transform.position;
            if (showDebug) { print("You have collided with the 1. teleporter"); }
        }
        
        if (mazeID == 1)
        {
            player.transform.position = teleportTarget2.transform.position;
            if (showDebug) { print("You have collided with the 2. teleporter"); }
        }
        
        if (mazeID == 2)
        {
            player.transform.position = teleportTarget3.transform.position;
            if (showDebug) { print("You have collided with the 3. teleporter"); }
        }
        
        if (mazeID == 3)
        {
            player.transform.position = teleportTarget4.transform.position;
            if (showDebug) { print("You have collided with the 4. teleporter"); }
        }
    }
}