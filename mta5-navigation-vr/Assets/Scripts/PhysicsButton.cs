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
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1) {
            Pressed();
            if (endpoint)
            {
                
                
                Debug.Log(("mazetag; " + WayPointChecker.MazeTag));
                timers[levelIndex] = Time.time - timers[levelIndex];
                Debug.Log("idfk1: " + Randomizer.idfk);
                endButtonPressd = true;
                startButtonPressd = false;
                timerStart = false;
                exitTimer = 0;
                //Debug.Log("New maze started");
                //randomizer.mazeArray[WayPointChecker.MazeID][1] = 1;
                //Debug.Log("mazeaarray" + randomizer.mazeArray);
                
               

            }
            if (!endpoint)
            {
                WayPointChecker.MazeTag += 1; 
                Player_Teleportation.onlyOne = true;
                GameObject newMaze = GameObject.Find("randomizerObject");
                newMaze.GetComponent<Randomizer>().updateMaze();
                
                if (WayPointChecker.MazeID == 1)
                {
                    Debug.Log("arrayIndex: " + FinalTempDis.arrayIndex);
                    FinalTempDis.arrayIndex = 3;
                }
                if (WayPointChecker.MazeID == 2)
                {
                    Debug.Log("arrayIndex: " + FinalTempDis.arrayIndex);
                    FinalTempDis.arrayIndex = 11;
                }
                if (WayPointChecker.MazeID == 3)
                {
                    Debug.Log("arrayIndex: " + FinalTempDis.arrayIndex);
                    FinalTempDis.arrayIndex = 18;
                }
                if (WayPointChecker.MazeID == 4)
                {
                    Debug.Log("arrayIndex: " + FinalTempDis.arrayIndex);
                    FinalTempDis.arrayIndex = 33;
                }
                
                timers[levelIndex] = Time.time;
                Debug.Log("Timer started");
                startButtonPressd = true;
                endButtonPressd = false;
                timerStart = true;
                
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
        Debug.Log("Pressed");
    }

    private void Released() {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

    
}