using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFreqDis : MonoBehaviour
{
    public Transform objective;
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

    //waypoint varibles
    public WayPointChecker checker;
    public GameObject[] wayPoints;
    private GameObject waypoint;
    public GameObject currentWayPoint;
    private int arrayIndex = 1;
    private List<GameObject> sortedWaypoint;
    private float savedDist;
    private float currentDist;


    void Start()
    {
        //Henter audiokilder vi har smidt p� objektet i r�kkef�lge: lav Hz -> h�j Hz
        audioSources = GetComponents<AudioSource>();
        holder = distance;
        startTimer = true;
        timerLimit = 1;

        //Her skal "objective" repr�sentere waypointet, og nok ned i Update med noget if statement der styrer hvilket waypoint vi skal mod
        distanceHolder = Vector3.Distance(transform.position, objective.transform.position);

        //Finder alle waypoints og sorter dem
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
        if (Input.GetButtonDown("Button1"))
        {
            Debug.Log("dafaq" + audioSources.Length);
            sonar = audioSources[1];
            sonar.Play();
        }

        if (startTimer) //K�rer funktionen i det definerede interval
        {
            timer += Time.deltaTime;
            if (timer >= timerLimit)
            {
                startDistanceDetection(transform, objective.transform);
                timer = 0f;
            }
        }

        //Ser om waypoint skal opdateres
        if (checker.imActive == false && arrayIndex < wayPoints.Length)
        {
            updateCurrentWayPoint();
        }
        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        Debug.Log(1 - currentDist / savedDist);
    }

    void startDistanceDetection(Transform navdevice, Transform objectives)
    {
        // Vi beregner nuv�rende afstand fra nav-device til waypoint og skalerer ift. den fulde afstand fra os til waypoint
        distance = Vector3.Distance(navdevice.position, currentWayPoint.transform.position);
        distanceScaled = 1 - (distance / distanceHolder);

        //Vi har 5 levels og laver procentvis fremgang for hver 20% t�ttere vi kommer p� waypoint (100/5=20)
        level = Mathf.CeilToInt((distanceScaled * 100f) / 20f);

        if (holder != distance) //Vi gider ikke lave noget n�r der ikke er nogen aktivitet alligevel
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
        currentWayPoint = wayPoints[wayPoints.Length - arrayIndex];
        arrayIndex += 1;
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
    }

}