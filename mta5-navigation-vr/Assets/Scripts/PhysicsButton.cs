using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PhysicsButton : MonoBehaviour
{
    //Variabler der skal bruges til at se, om knappen bliver trykket på, og ikke bare er et fejltryk
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;


    private AudioSource buip;
    //Skal se knappens position
    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    private Randomizer randomizer;
    public static bool startButtonPressd;
    public static bool endButtonPressd;
    public static bool firstPress = false;

    public static bool maze1Bool;
    public static bool maze2Bool;
    public static bool maze3Bool;
    public static bool maze4Bool;

    // Vi bruger physicsButton til enten at starte en timer eller skifte level.
    public bool endpoint;
    public static int levelIndex;
    
    // Timers til at måle tid
    public static float[] timers;

    // Allowed maze time
    public static bool timerStart;
    public static float exitTimer;

    //Laver nogle unity events, der bliver triggered når knappen bliver trykket.
    public UnityEvent onPressed, onReleased;

    public GameObject maze;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //start positionen er sat til knappens lokale position, da det er knappens position vi er ude efter, og ikke en position kontra en anden position.
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        randomizer = GetComponent<Randomizer>();
        timers = new float[5];
        buip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1) {
            Pressed();
            if (endpoint)
            {
                
                
                timers[levelIndex] = Time.time - timers[levelIndex];
                endButtonPressd = true;
                startButtonPressd = false;
                timerStart = false;
                exitTimer = 0;
                Debug.Log("End button pressed");
                //randomizer.mazeArray[WayPointChecker.MazeID][1] = 1;
                //Debug.Log("mazeaarray" + randomizer.mazeArray);
                buip.Play();


            }
            if (!endpoint)
            {
                WayPointChecker.MazeTag += 1; 
                Player_Teleportation.onlyOne = true;
                
                
                
                timers[levelIndex] = Time.time;
                Debug.Log("Start button pressed");
                startButtonPressd = true;
                endButtonPressd = false;
                timerStart = true;
                buip.Play();
                
            }
            
        }
        
    }

    //Ser om distance mellem knappens start position og knappens nuværende position er stor nok til at gå ud over dødszonen
    private float GetValue() {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone) {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    //Metoder der kalder et unity event
    private void Pressed()
    {
        isPressed = true;
        
        onPressed.Invoke();
    }

    private void Released() {
        isPressed = false;
        onReleased.Invoke();
    }

    
}