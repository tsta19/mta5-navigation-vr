using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FinalTempDis : MonoBehaviour
{
    // Instantiates a lot of variables.
    [SerializeField] private string objectiveTag = "Objective";

    [SerializeField] private LayerMask wallMask;
    [SerializeField] private GameObject currentHit;
    [SerializeField] private Vector3 objectiveCollision = Vector3.zero;

    [SerializeField] private Transform navDevicePointer;
    [SerializeField] private Transform objectivePos;
    //public TextMeshPro textTimer;
    private LineRenderer lineRenderer;
    public float playerDistFromObj;
    public AudioSource audioSource;
    private float pitchStart = 0.508f;
    private float pitchNow;
    public float holder;
    public float audioMixPitch;
    public float timerStart;
    public float timerEnd;
    public float timeSpentHolder;
    public float timeSpent;
    public float startDis;
    public float normalizedValue;
    public float pitchMap;
    public InputActionReference toggleReference = null;
    public InputActionReference toggleOffReference = null;

    //Start function whitch initializes some starting variables.
    void Start()
    {
        connectLines(true);
        distanceFromPlayerToObjective();
        audioSource.pitch = pitchStart;
        Initialization();
        Debug.Log("startdisfromobj: " + playerDistFromObj);
        startDis = playerDistFromObj;
    }

    void Update()
    {
        // If the distance from the endgoal object changes(it moves) run this code.
        if (holder != playerDistFromObj)
        {
            // If statement making sure pitch stays between the stated values.
            if (audioSource.pitch > 0.507 && audioSource.pitch < 2.005)
            {
                // Maps the pitch values to the distance.
                normalizedValue = Mathf.InverseLerp(startDis, 0, playerDistFromObj);
                pitchMap = Mathf.Lerp(0.508f, 2.004f, normalizedValue);
                // Saves the into the variable witch holds the current pitch.
                pitchNow = pitchMap;
                audioSource.pitch = pitchNow;
                // Decreases or increases the pitch to counterbalance the increase/decrease audiosource.Pitch does so that
                // we only end up with the tempo increase.
                audioSource.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1.0f / audioSource.pitch);
                Debug.Log("Pitch: " + audioSource.pitch);
                // Saves the current player distance into the holder variable to show the player is not moving again.
                holder = playerDistFromObj;
            }
            else
            {
                // Makes sure the pitch doesn't go over or under max or min value.
                audioSource.pitch = pitchNow;
            }


        }
        // Thomas kode til distance.
        connectLines(true);
        distanceFromPlayerToObjective();

        // When you press 1 this code starts playing the audiosource sound and loops it, and starts the timer.
        //if (Input.GetButtonDown("button1"))

        //{
        //    audioSource.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1.0f / audioSource.pitch);
        //    timerStart = Time.time;
        //    audioSource.Play();
        //    audioSource.loop = true;


        //}

        //// When you press 2 this code runs which saves the time spent listening and stops the looping.
        //if (Input.GetButtonDown("button2"))
        //{
        //    timerEnd = Time.time;
        //    timeSpentHolder = timerEnd - timerStart;
        //    timeSpent += timeSpentHolder;
        //    Debug.Log("Total button time spent: " + timeSpent);
        //    audioSource.loop = false;
        //}
    }

    // Thomas kode.
    void connectLines(bool state)
    {
        if (state)
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, navDevicePointer.transform.position);
            lineRenderer.SetPosition(1, objectivePos.transform.position);
            playerDistFromObj = Vector3.Distance(navDevicePointer.transform.position, objectivePos.transform.position);
        }
        else
        {
            return;
        }
    }

    private void Initialization()
    {
        Debug.Log(this.gameObject.GetComponent<MonoBehaviour>() + " Script Started");
    }

    private void distanceFromPlayerToObjective()
    {
        var ray = new Ray(navDevicePointer.position, navDevicePointer.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, ~wallMask))
        {
            currentHit = hit.transform.gameObject;
            objectiveCollision = hit.point;

            if (currentHit.CompareTag(objectiveTag))
            {
                // If objective is hit, code goes here
            }
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
        audioSource.outputAudioMixerGroup.audioMixer.SetFloat("pitchBend", 1.0f / audioSource.pitch);
        timerStart = Time.time;
        audioSource.Play();
        audioSource.loop = true;
    }

    private void ToggleOff(InputAction.CallbackContext context)
    {
        timerEnd = Time.time;
        timeSpentHolder = timerEnd - timerStart;
        timeSpent += timeSpentHolder;
        Debug.Log("Total button time spent: " + timeSpent);
        audioSource.loop = false;
    }
}
