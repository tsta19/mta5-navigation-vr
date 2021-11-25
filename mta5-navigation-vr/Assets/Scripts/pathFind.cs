using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathFind : MonoBehaviour
{
    [SerializeField]
    Transform destination;
    [SerializeField]
    Transform thisObject;
    NavMeshAgent navMeshAgent;
    private bool enGang;
    Vector3 oldPos;
    float totalDistance;


    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        enGang = true;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (destination == null) { Debug.Log("destination not set brutha"); }
        else { setDestination(); }

    }

 

    // Update is called once per frame
    void Update()
    {

        Vector3 distanceVector = transform.position - oldPos;
        float distanceThisFrame = distanceVector.magnitude;
        totalDistance += distanceThisFrame;
        oldPos = transform.position;

        if (thisObject.transform.position.x == destination.transform.position.x && thisObject.transform.position.z == destination.transform.position.z && enGang == true)
        {
            Debug.Log("Minimum completion time: " + Time.time);
            enGang = false;
            Debug.Log("Minimum distance travelled: " + totalDistance);
        }
        
    }

    private void setDestination()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
        

    }
}
