using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Teleportation : MonoBehaviour
{
    // Get mazeID
    public GameObject maze;

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
        GameObject randomizer = GameObject.Find("randomizerObject");
        maze = randomizer.GetComponent<Randomizer>().getMaze();
        Transform child = maze.transform.Find("Teleporter").transform.Find("TeleportTarget");
        player.transform.position = child.transform.position;
    
        /*if (WayPointChecker.MazeID == 0)
        {
            Transform child = maze.transform.Find("Teleporter").transform.Find("TeleportTarget");
            player.transform.position = child.transform.position;
            if (showDebug) { print("You have collided with the 1. teleporter"); }
        }
        
        if (WayPointChecker.MazeID == 1)
        {
            player.transform.position = maze.teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 2. teleporter"); }
        }
        
        if (WayPointChecker.MazeID == 2)
        {
            player.transform.position = maze.teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 3. teleporter"); }
        }
        
        if (WayPointChecker.MazeID == 3)
        {
            player.transform.position = maze.teleportTarget.transform.position;
            if (showDebug) { print("You have collided with the 4. teleporter"); }
        }*/
    }
}