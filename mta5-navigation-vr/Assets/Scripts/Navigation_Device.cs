using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation_Device : MonoBehaviour
{
    [SerializeField] private string objectiveTag = "Objective";

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private GameObject currentHit;
    [SerializeField] private Vector3 objectiveCollision = Vector3.zero;

    [SerializeField] private Transform navDevicePointer;
    [SerializeField] private Transform objectivePos;

    private LineRenderer lineRenderer;
        
    void Start()
    {
        Initialization();
    }

    void Update()   
    {
        connectLines(true);
        distanceFromPlayerToObjective();
    }

    void connectLines(bool state)
    {
        if (state)
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, navDevicePointer.transform.position);
            lineRenderer.SetPosition(1, objectivePos.transform.position);
            var playerDistFromObj = Vector3.Distance(navDevicePointer.transform.position, objectivePos.transform.position);
        } else 
        {
            return;
        }
    }

    private void Initialization()
    {
        Debug.Log(this.gameObject.GetComponent<MonoBehaviour>() + " Script Started");
    }

    private void distanceFromPlayerToObjective()
    {
        var ray = new Ray(navDevicePointer.position, navDevicePointer.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, ~wallMask))
        {
            currentHit = hit.transform.gameObject;
            objectiveCollision = hit.point;

            if (currentHit.CompareTag(objectiveTag))
            {
                // If objective is hit, code goes here
            }
        }
    }
}
