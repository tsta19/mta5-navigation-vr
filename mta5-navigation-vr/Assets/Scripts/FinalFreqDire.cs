using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinalFreqDire : MonoBehaviour
{
    private Vector3 _directionVector;
    private float angle;
    public AudioSource[] audioSources;
    private AudioSource sonar1;
    private int level = 5;
    private float holder;
    public float timerLimit;
    private float timer;
    public bool startTimer;
    public InputActionReference toggleReference = null;
    public InputActionReference toggleOffReference = null;
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
   
    private List<GameObject> sortedWaypoint;
    private float savedDist;
    private float currentDist;

    //Navigation activation variables
    private float runTimer;
    private float activeTime;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSources = GetComponents<AudioSource>();

        holder = Mathf.Abs(angle);
        startTimer = false;
        timerLimit = 1;
        
        updateSortedArray();
    }

    void Update()
    {
        
        checkIfNewMaze();
        
        //buttonPress();
        //buttonRelease();

        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= timerLimit)
            {
                //Debug.Log("hejsa");
                startDetection();
                timer = 0f;
            }
        }

        if (checker.imActive == false && FinalTempDis.arrayIndex < wayPoints.Length)
        {
            updateCurrentWayPoint();
        }

        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        
    }

    void startDetection()
    {
        //Vi finder retningsvektoren mellem nav-device og waypoint
        _directionVector = currentWayPoint.transform.position - transform.position;

        //beregner vinkel mellem retningsvektor og nav-device's frontvektor
        angle = Vector3.SignedAngle(_directionVector, transform.forward, Vector3.forward);
        //Debug.Log("angle: " + angle);
        //Scaler level efter grader (op til vinkelret)
        level = Mathf.Abs(Mathf.CeilToInt(angle / 18));
        //Debug.Log("level: " + level);
        if (Mathf.Abs(holder) != Mathf.Abs(angle))
        {
            if (level < 5)
            {
                sonar1 = audioSources[level];
                sonar1.Play();
                holder = angle;
            }
            else
            {
                audioSources[4].Play();
            }
        }
    }

    public void updateCurrentWayPoint()
    {
        print("previous waypoint: " + currentWayPoint);
        currentWayPoint = sortedWaypoint[FinalTempDis.arrayIndex];
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        Debug.Log("current" + currentWayPoint);
        print("currentMazeID: " + WayPointChecker.MazeID);
    }
    
    void updateSortedArray()
    {
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
        //print("sorted" + sortedWaypoint);
        updateCurrentWayPoint();
    }

    void checkIfNewMaze()
    {
        if (PhysicsButton.maze1Bool)
        {
            updateCurrentWayPoint();
            PhysicsButton.maze1Bool = false;
            
        }
       
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
        startTimer = true;
        deviceButtonClickStart = 1;
        startButtonClickTimer = true;
        deviceButtonClickTimerStart = Time.time;
        deviceButtonClickStop = 0;
    }

    private void ToggleOff(InputAction.CallbackContext context)
    {
        toggleOffID += 1;
        Debug.Log("ToggleOff" + toggleOffID);
        startTimer = false;
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
    
    //private void buttonPress()
    //{
    //    if (Input.GetKeyDown("t"))
    //    {
    //        toggleOnID += 1;
    //        Debug.Log("ToggleOn" + toggleOnID);
    //        startTimer = true;
    //        deviceButtonClickStart = 1;
    //        Debug.Log("DBCSTART " + deviceButtonClickStop);
    //        deviceButtonClickTimerStart = Time.time;
    //        deviceButtonClickStop = 0;
            
    //    }
    //}

    //private void buttonRelease()
    //{
    //    if (Input.GetKeyDown("y"))
    //    {
    //        toggleOffID += 1;
    //        Debug.Log("ToggleOff" + toggleOffID);
    //        startTimer = false;
    //        deviceButtonClickStop = 1;
    //        Debug.Log("DBCSTOP " + deviceButtonClickStop);
    //        deviceButtonClickTimerEnd = Time.time;
    //        deviceButtonClickTimerSpent = deviceButtonClickTimerEnd - deviceButtonClickTimerStart;
    //        deviceButtonClickTimerSpentHolder = deviceButtonClickTimerSpent;
    //        deviceButtonClickTimerTotal += deviceButtonClickTimerSpent;
    //        Debug.Log("Device On in seconds " + deviceButtonClickTimerSpent);
    //        deviceButtonClickTimerSpent = 0f;
    //        deviceButtonClickStart = 0;
    //    }
    //}
}