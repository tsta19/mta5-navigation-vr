using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFreqDire : MonoBehaviour
{
    private Vector3 _directionVector;
    public Transform objective;
    private float angle;
    public AudioSource[] audioSources;
    private AudioSource sonar1;
    private int level = 5;
    private float holder;
    public float timerLimit;
    private float timer;
    public bool startTimer;

    //waypoint varibles
    public WayPointChecker checker;
    public GameObject[] wayPoints;
    private GameObject waypoint;
    private GameObject currentWayPoint;
    private int arrayIndex = 1;
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
        startTimer = true;
        timerLimit = 1;

        //Find all waypoints in the 
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        sortedWaypoint = new List<GameObject>();
        for (int i = 1; i <= wayPoints.Length; i++)
        {
            waypoint = GameObject.Find("Waypoint" + i);
            sortedWaypoint.Add(waypoint);
        }

        updateCurrentWayPoint();
    }

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= timerLimit)
            {
                startDetection();
                timer = 0f;
            }
        }

        if (checker.imActive == false && arrayIndex < wayPoints.Length)
        {
            updateCurrentWayPoint();
        }

        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        Debug.Log(1 - currentDist / savedDist);
    }

    void startDetection()
    {
        //Vi finder retningsvektoren mellem nav-device og waypoint
        _directionVector = currentWayPoint.transform.position - transform.position;

        //beregner vinkel mellem retningsvektor og nav-device's frontvektor
        angle = Vector3.SignedAngle(_directionVector, transform.forward, Vector3.forward);

        //Scaler level efter grader (op til vinkelret)
        level = Mathf.Abs(Mathf.CeilToInt(angle / 18));
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
        currentWayPoint = wayPoints[wayPoints.Length - arrayIndex];
        arrayIndex += 1;
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
    }
}