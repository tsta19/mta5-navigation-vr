using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointChecker : MonoBehaviour
{
    public bool imActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            imActive = false;
            Debug.Log("HE GOT ME!");
        }
    }
}
