using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceCalc : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 oldPos;
    float totalDistance;

    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        oldPos = transform.position;
        Debug.Log("Distance travelled: " + totalDistance);
    }
}
