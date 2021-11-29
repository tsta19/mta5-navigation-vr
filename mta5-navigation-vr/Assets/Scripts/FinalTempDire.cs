using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class FinalTempDire : MonoBehaviour
{
    private Vector3 _directionVector;
    private float angle;
    public AudioSource sonar1;
    private float holder;
    private float startAngle;
    private float normalizedValue;
    public float pitchMap;
    public InputActionReference toggleReference = null;
    public InputActionReference toggleOffReference = null;

    //Logging
    [HideInInspector] public int deviceButtonClickStart;
    [HideInInspector] public int deviceButtonClickStop;
    [HideInInspector] public float deviceButtonClickTimer;
    [HideInInspector] public bool startButtonClickTimer = false;


    [HideInInspector] public float deviceButtonClickTimerStart;
    [HideInInspector] public float deviceButtonClickTimerEnd;
    [HideInInspector] public float deviceButtonClickTimerSpent;
    [HideInInspector] public float deviceButtonClickTimerSpentHolder;
    [HideInInspector] public float deviceButtonClickTimerTotal;

    [HideInInspector] public int toggleOnID;
    [HideInInspector] public int toggleOffID;

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

    private void Awake()
    {
        toggleReference.action.started += Toggle;
        toggleOffReference.action.started += ToggleOff;
    }

    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
        toggleOffReference.action.started -= ToggleOff;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        toggleOnID += 1;
        Debug.Log("ToggleOn" + toggleOnID);
        deviceButtonClickStart = 1;
        startButtonClickTimer = true;
        deviceButtonClickTimerStart = Time.time;
        deviceButtonClickStop = 0;
    }

    private void ToggleOff(InputAction.CallbackContext context)
    {
        toggleOffID += 1;
        Debug.Log("ToggleOff" + toggleOffID);
        deviceButtonClickStop = 1;
        startButtonClickTimer = false;
        deviceButtonClickTimerEnd = Time.time;
        deviceButtonClickTimerSpent = deviceButtonClickTimerEnd - deviceButtonClickTimerStart;
        deviceButtonClickTimerSpentHolder = deviceButtonClickTimerSpent;
        deviceButtonClickTimerTotal += deviceButtonClickTimerSpent;
        Debug.Log("Device On in seconds " + deviceButtonClickTimerSpent);
        deviceButtonClickTimerSpent = 0f;
        deviceButtonClickStart = 0;
    }


}


