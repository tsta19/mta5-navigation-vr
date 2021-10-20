using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tracking : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private GameObject playerTracerObject;

    private double nextTracerTime = 0.0f;
    private double timeBetweenTracer = .5f;
    private int playerPosCounter = 0;

    List<Vector3> playerPositionsArray = new List<Vector3>();
    List<float> totalDistanceBtwPoints = new List<float>();

    private LineRenderer lineRenderer;


    // Update is called once per frame
    void Update()
    {
        if (playerPosCounter != 20)
        {
            if (Time.time > nextTracerTime)
            {
                nextTracerTime += timeBetweenTracer;
                playerPositionsArray.Add(playerPosition.position);
                playerPosCounter++;
                Debug.Log(playerPosCounter);
                // for (int i = 0; i < playerPositionsArray.Count; i++)
                // {
                //Debug.Log(playerPositionsArray[i].ToString() + " ARRAY POSITION");
                //Debug.Log(playerPositionsArray.Count + " ARRAY LENGTH");
                // }
            }
        }
    }

    void CalcDistBtwPoints()
    {
        for (int i = 0; i < playerPositionsArray.Count; i++)
        {
            totalDistanceBtwPoints.Add(Vector3.Distance(playerPositionsArray[i], playerPositionsArray[i + 1]));
            Debug.Log("DISTANCE BTW POINTS " + totalDistanceBtwPoints[i]);
        }
    }
}
