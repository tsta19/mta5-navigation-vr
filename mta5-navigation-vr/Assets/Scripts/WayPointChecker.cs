using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointChecker : MonoBehaviour
{
    private AudioSource audioSources;
    public static int MazeID;
    public static int MazeTag;
    public int mazeChecker;
    public bool imActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            audioSources = GetComponent<AudioSource>();
            audioSources.Play();
            imActive = false;
            Debug.Log("HE GOT ME!");
            //confirmationsound
        }
    }
}
