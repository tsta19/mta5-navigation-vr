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
    public float timer;
    public bool printEn;


    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(navMeshAgent == null) { Debug.Log("No navmesh agent bruh"); }
        else { setDistination(); }
        
        printEn = true;

    }


    // Update is called once per frame
    void Update()
    {
        if (thisObject.transform.position.x == destination.transform.position.x && thisObject.transform.position.z == destination.transform.position.z && 
            printEn == true)
        {
            Debug.Log("Minimum completion time:" + Time.time);
            printEn = false;
        }
    }

    private void setDistination()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshAgent.SetDestination(targetVector);
        }
    }
}
