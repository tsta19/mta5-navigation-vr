using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinalFreqDis : MonoBehaviour
{
    
    private int level;
    private float holder;
    public AudioSource[] audioSources;
    private AudioSource sonar;
    private bool startTimer;
    public float timerLimit;
    private float timer;
    private float distance;
    private float distanceHolder;
    private float distanceScaled;
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
    private int arrayIndex = 0;
    private List<GameObject> sortedWaypoint;
    private float savedDist;
    private float currentDist;


    void Start()
    {
        //Henter audiokilder vi har smidt på objektet i rœkkefølge: lav Hz -> høj Hz
        audioSources = GetComponents<AudioSource>();
        
        startTimer = true;
        timerLimit = 1;


        updateSortedArray();
        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        distanceHolder = currentDist;
    }


    void Update()
    {
        
        checkIfNewMaze();
        if (startTimer) //Kører funktionen i det definerede interval
        {
            timer += Time.deltaTime;
            if (timer >= timerLimit)
            {
                startDistanceDetection();
                timer = 0f;
            }
        }

        //Ser om waypoint skal opdateres
        if (checker.imActive == false && arrayIndex < wayPoints.Length)
        {
            updateCurrentWayPoint();
            currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
            distanceHolder = currentDist;



        }
        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
       
    }

    void startDistanceDetection()
    {
        // Vi beregner nuvœrende afstand fra nav-device til waypoint og skalerer ift. den fulde afstand fra os til waypoint
        distance = Vector3.Distance(transform.position, currentWayPoint.transform.position);
        distanceScaled = 1 - (distance / distanceHolder);

        //Vi har 5 levels og laver procentvis fremgang for hver 20% tœttere vi kommer på waypoint (100/5=20)
        level = Mathf.CeilToInt((100f - distanceScaled * 100f) / 20f);
        if (holder != distance) //Vi gider ikke lave noget når der ikke er nogen aktivitet alligevel
        {
            if (level < 5)
            {
                sonar = audioSources[level];
                sonar.Play();
                holder = distance;
            }
            else
            {
                sonar = audioSources[4];
                sonar.Play();
            }
        }
    }

    void updateCurrentWayPoint()
    {
        currentWayPoint = sortedWaypoint[FinalTempDis.arrayIndex];
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);

    }
    private void Awake()
    {
        toggleReference.action.started += Toggle;
        toggleOffReference.action.started += ToggleOff;
    }
    void updateSortedArray()
    {
        print("hej");
        //Find all waypoints in the 
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        sortedWaypoint = new List<GameObject>();
        for (int i = 1; i <= wayPoints.Length; i++)
        {
            waypoint = GameObject.Find("Waypoint" + i);
            sortedWaypoint.Add(waypoint);
            print("LÆNGDE" + wayPoints.Length);
            print("NAVN" + waypoint);
            print("hejsaaaaaa");
            //if (WayPointChecker.MazeID == sortedWaypoint[i-1].GetComponent<WayPointChecker>().mazeChecker)
            
                
            
        }
        //print("sorted" + sortedWaypoint);
        updateCurrentWayPoint();
    }    
    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
        toggleOffReference.action.started -= ToggleOff;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        startTimer = true;
    }

    private void ToggleOff(InputAction.CallbackContext context)
    {
        startTimer = false;
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



