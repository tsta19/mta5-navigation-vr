using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FinalTempDis : MonoBehaviour
{
    // Instantiates a lot of variables.

    private bool fyrDen;

    private Transform navDevicePointer;
    private Transform objectivePos;

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

    //public TextMeshPro textTimer;
    private LineRenderer lineRenderer;
    public AudioSource audioSource;
    private float pitchStart = 0.508f;
    private float pitchNow;
    private float holder;
    public float audioMixPitch;
    private float timerStart;
    private float timerEnd;
    private float timeSpentHolder;
    private float timeSpent;
    private float startDis;
    private float normalizedValue;
    private float pitchMap;
    public InputActionReference toggleReference = null;
    public InputActionReference toggleOffReference = null;
    
    //waypoint varibles
    public WayPointChecker checker;
    public GameObject[] wayPoints;
    private GameObject waypoint;
    private GameObject currentWayPoint;
    public static int arrayIndex = 0;
    private List<GameObject> sortedWaypoint;
    private float savedDist;
    private float currentDist;

    //Start function whitch initializes some starting variables.
    void Start()
    {
        //connectLines(true);
        //distanceFromPlayerToObjective();
        audioSource.pitch = pitchStart;
        //Initialization();
       
        
        
        //Find all waypoints in the 
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        sortedWaypoint = new List<GameObject>();
        for (int i = 1; i <= wayPoints.Length; i++)
        {
            waypoint = GameObject.Find("Waypoint" + i);
            sortedWaypoint.Add(waypoint);
            //print("LÆNGDE" + wayPoints.Length);
            //print("NAVN" + waypoint);
            
        }
        updateCurrentWayPoint();
       
        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        startDis = currentDist;
    }

    void Update()
    {
        checkIfNewMaze();
        // If the distance from the endgoal object changes(it moves) run this code.
        if (holder != currentDist)
        {
            // If statement making sure pitch stays between the stated values.
            if (audioSource.pitch > 0.507 && audioSource.pitch < 2.005)
            {
                // Maps the pitch values to the distance.
                normalizedValue = Mathf.InverseLerp(startDis, 0, currentDist);
                pitchMap = Mathf.Lerp(0.508f, 2.004f, normalizedValue);
                // Saves the into the variable witch holds the current pitch.
                pitchNow = pitchMap;
                audioSource.pitch = pitchNow;
                // Decreases or increases the pitch to counterbalance the increase/decrease audiosource.Pitch does so that
                // we only end up with the tempo increase.
                audioSource.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1.0f / audioSource.pitch);
                // Saves the current player distance into the holder variable to show the player is not moving again.
                holder = currentDist;
            }
            else
            {
                // Makes sure the pitch doesn't go over or under max or min value.
                audioSource.pitch = pitchNow;
            }
            
            if (checker.imActive == false && arrayIndex < wayPoints.Length)
            {
                updateCurrentWayPoint();
                
            }
           

        }

        if (fyrDen)
        {
            audioSource.Play();
            fyrDen = false;
        }
        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        // Thomas kode til distance.
        //connectLines(true);
        //distanceFromPlayerToObjective();

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
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1.0f / audioSource.pitch);
        timerStart = Time.time;
        fyrDen = true;
        audioSource.loop = true;
        deviceButtonClickStart = 1;
        startButtonClickTimer = true;
        deviceButtonClickTimerStart = Time.time;
        deviceButtonClickStop = 0;
    }

    private void ToggleOff(InputAction.CallbackContext context)
    {
        toggleOffID += 1;
        audioSource.loop = false;
        deviceButtonClickStop = 1;
        startButtonClickTimer = false;
        deviceButtonClickTimerEnd = Time.time;
        deviceButtonClickTimerSpent = deviceButtonClickTimerEnd - deviceButtonClickTimerStart;
        deviceButtonClickTimerSpentHolder = deviceButtonClickTimerSpent;
        deviceButtonClickTimerTotal += deviceButtonClickTimerSpent;
        deviceButtonClickTimerSpent = 0f;
        deviceButtonClickStart = 0;
    }
    
    void updateCurrentWayPoint()
    {
        currentWayPoint = sortedWaypoint[arrayIndex];
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        
    }
    void checkIfNewMaze()
    {
        if (PhysicsButton.maze1Bool)
        {
            updateCurrentWayPoint();
            PhysicsButton.maze1Bool = false;

        }
    }
}
