using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public WayPointChecker checker;
    public GameObject[] wayPoints;
    private GameObject waypoint;
    public GameObject currentWayPoint;
    private int arrayIndex = 1;
    private List<GameObject> sortedWaypoint;
    private float savedDist;
    private float currentDist;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("WayPoint");
        sortedWaypoint = new List<GameObject>();
        for (int i = 1; i <= wayPoints.Length; i++) {
            waypoint = GameObject.Find("Waypoint" + i);
            sortedWaypoint.Add(waypoint);
        }
        updateCurrentWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (checker.imActive == false && arrayIndex < wayPoints.Length) {
            updateCurrentWayPoint();
        }
        currentDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
        Debug.Log(1 - currentDist / savedDist);
    }

    void updateCurrentWayPoint() {
        currentWayPoint = wayPoints[wayPoints.Length - arrayIndex];
        arrayIndex += 1;
        checker = currentWayPoint.GetComponent<WayPointChecker>();
        checker.imActive = true;
        savedDist = Vector3.Distance(currentWayPoint.transform.position, transform.position);
    }
}
