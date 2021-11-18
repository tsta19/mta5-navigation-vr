using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tracking : MonoBehaviour
{
	[SerializeField] private Transform playerPosition;

	private float nextTracerTime = 0.0f; // Time before next tracer will be placed (Now instantaneous)
	private float timeBetweenTracer = 1.0f; // In seconds
	private int playerPosCounter = 0; // Counter which controls the amount of positions it will trace before disabling

	List<Vector3> playerPositionsArray = new List<Vector3>();
	List<float> totalDistanceBtwPoints = new List<float>();
	
	private LineRenderer lineRenderer;

	void Start()
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update()
	{
		if (playerPosCounter != 45)
		{
			if (Time.time > nextTracerTime)
			{
				nextTracerTime += timeBetweenTracer;
				playerPositionsArray.Add(playerPosition.position);
				playerPosCounter++;
				Debug.Log(playerPosCounter);
			}
		} else
		{
			TrackPlayerPosition(playerPositionsArray);
		}
	}

	void TrackPlayerPosition(List<Vector3> arrayReceive)
	{

		for (int i = 0; i < (arrayReceive.Count - 1); i++)
		{
			lineRenderer.SetVertexCount(arrayReceive.Count);
			lineRenderer.positionCount = arrayReceive.Count;
			lineRenderer.SetPosition(i, arrayReceive[i]);
			lineRenderer.SetPosition(i + 1, arrayReceive[i + 1]);
		}
	}
}

