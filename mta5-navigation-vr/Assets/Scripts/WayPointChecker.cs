using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointChecker : MonoBehaviour
{
    public static int MazeID;
    public static int MazeTag;
    public int mazeChecker;
    public bool imActive;

    void start(){
        audioSources = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            magic.Play();
            imActive = false;
            Debug.Log("HE GOT ME!");
            //confirmationsound
        }
    }
}
