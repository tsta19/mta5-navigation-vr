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

    //waypoint varibles
    public WayPointChecker checker;
    public GameObject[] wayPoints;
    private GameObject waypoint;
    private GameObject currentWayPoint;
    private int arrayIndex = 0;
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
 
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= timerLimit)
            {
                Debug.Log("hejsa");
                startDetection();
                timer = 0f;
            }
        }

        if (checker.imActive == false && arrayIndex < wayPoints.Length)
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
        Debug.Log("angle: " + angle);
        //Scaler level efter grader (op til vinkelret)
        level = Mathf.Abs(Mathf.CeilToInt(angle / 18));
        Debug.Log("level: " + level);
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

    void updateCurrentWayPoint()
    {
        currentWayPoint = sortedWaypoint[arrayIndex];
        arrayIndex += 1;
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        Debug.Log("current" + currentWayPoint);
        
    }
    
    void updateSortedArray()
    {
        //Find all waypoints in the 
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        sortedWaypoint = new List<GameObject>();
        for (int i = 1; i <= wayPoints.Length; i++)
        {
            if (WayPointChecker.MazeID == WayPointChecker.MazeTag)
            {
                waypoint = GameObject.Find("Waypoint" + i);
                sortedWaypoint.Add(waypoint);
                print("LÆNGDE" + wayPoints.Length);
                print("NAVN" + waypoint);
            }
        }
        print("sorted" + sortedWaypoint);
        updateCurrentWayPoint();
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
        Debug.Log("knaptryk");
        startTimer = true;
    }

    private void ToggleOff(InputAction.CallbackContext context)
    {
        startTimer = false;
    }
}