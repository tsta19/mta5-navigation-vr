using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Teleportation : MonoBehaviour
{
    // Get mazeID
    public GameObject maze;

    public static bool isForceTP;
    // Player Reference
    public GameObject player;
    public GameObject device;

    private FinalFreqDire finalFreqDire;
    // Teleport Reference
    public Transform teleportTarget1;
    public Transform teleportTarget2;
    public Transform teleportTarget3;
    public Transform teleportTarget4;
    public Transform teleportTarget5;
    

    // Debug Boolean
    private bool showDebug = true;
    public static bool onlyOne;

    private void OnTriggerEnter(Collider col)
    {
        teleport();
    
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

    private void FixedUpdate()
    {
        if (PhysicsButton.timerStart) {
            PhysicsButton.exitTimer += Time.deltaTime;
            
            if (PhysicsButton.exitTimer > 1500) {
                forceTeleport();
                PhysicsButton.exitTimer = 0;
                PhysicsButton.timerStart = false;
            }
        }
    }

    void teleport()
    {
        if (onlyOne)
        {
            if (PhysicsButton.firstPress)
            {
                Randomizer.idfk++;
            }
            
            GameObject randomizer = GameObject.Find("randomizerObject");
            maze = randomizer.GetComponent<Randomizer>().getMaze();
            Transform child = maze.transform.Find("Teleporter").transform.Find("TeleportTarget");
            player.transform.position = child.transform.position;
            device = GameObject.Find("GrabInteractable");
            device.transform.position = child.transform.position;
            onlyOne = false;
            GameObject newMaze = GameObject.Find("randomizerObject");
            newMaze.GetComponent<Randomizer>().updateMaze();
            PhysicsButton.maze1Bool = true;
            PhysicsButton.firstPress = true;
        }
        

    }
    void forceTeleport()
    {
        isForceTP = true;
        GameObject randomizer = GameObject.Find("randomizerObject");
        randomizer.GetComponent<Randomizer>().updateMaze();
        teleport();
        
     }
}