using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FinalTempDire : MonoBehaviour
{
    private Vector3 _directionVector;
    private float angle;
    public AudioSource sonar1;
    private float holder;
    private float startAngle;
    private float normalizedValue;
    public float pitchMap;
    
    //waypoint varibles
    public WayPointChecker checker;
    public GameObject[] wayPoints;
    private GameObject waypoint;
    private GameObject currentWayPoint;
    private int arrayIndex = 0;
    private List<GameObject> sortedWaypoint;
    private float savedDist;
    private float currentDist;


    // In the start function we call the startDetection method to setup the starting angle and holder.
    void Start()
    {
        startDetection();
        holder = Mathf.Abs(angle);
        startAngle = angle;     
        
        //Find all waypoints in the 
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        sortedWaypoint = new List<GameObject>();
        for (int i = 1; i <= wayPoints.Length; i++)
        {
            waypoint = GameObject.Find("Waypoint" + i);
            sortedWaypoint.Add(waypoint);
            print("LÆNGDE" + wayPoints.Length);
            print("NAVN" + waypoint);
            
        }
        print("sorted" + sortedWaypoint);
        updateCurrentWayPoint();
    }

    // Update function which plays the detection code every frame, and some code to check if the "1" button has been pressed.
    void Update()
    {

        startDetection();
        
        if (checker.imActive == false && arrayIndex < wayPoints.Length)
        {
            updateCurrentWayPoint();
        }

        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);

    }


    // Detection function which calculates the angle between start object and end object. 
    // It then uses this angle value to change the pitch. 
    void startDetection()
    {
        _directionVector = currentWayPoint.transform.position - transform.position;
        angle = Vector3.SignedAngle(_directionVector, transform.forward, Vector3.forward);

        if (Mathf.Abs(holder) != Mathf.Abs(angle))
        {
            normalizedValue = Mathf.InverseLerp(startAngle, 0, angle);
            pitchMap = Mathf.Lerp(0.508f, 2.004f, normalizedValue);
            sonar1.pitch = pitchMap;
            sonar1.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1.0f / sonar1.pitch);
            holder = angle;
        }
    }
    
    void updateCurrentWayPoint()
    {
        currentWayPoint = sortedWaypoint[arrayIndex];
        arrayIndex += 1;
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        Debug.Log("current" + currentWayPoint);
        
    }


}


