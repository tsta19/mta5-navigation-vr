using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceCalc : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 oldPos;
    public static float totalDistance;

    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PhysicsButton.startButtonPressd)
        {
            if (oldPos.x == transform.position.x || oldPos.z == transform.position.z)
            {
                LoggingMazeData.isMoving = false;

            }
            else
            {
                LoggingMazeData.isMoving = true;

            }
            Vector3 distanceVector = transform.position - oldPos;
            float distanceThisFrame = distanceVector.magnitude;
            totalDistance += distanceThisFrame;
            oldPos = transform.position;
            //Debug.Log("Distance travelled: " + totalDistance);
        }
        
        
    }
    
    
}
