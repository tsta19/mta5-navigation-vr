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

    // Vi bruger physicsButton til enten at starte en timer eller skifte level.
    public bool endpoint;
    private int levelIndex;
    
    // Timers til at måle tid
    private float[] timers;

    //Laver nogle unity events, der bliver triggered når knappen bliver trykket.
    public UnityEvent onPressed, onReleased;
    
    // Start is called before the first frame update
    void Start()
    {
        //start positionen er sat til knappens lokale position, da det er knappens position vi er ude efter, og ikke en position kontra en anden position.
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
        timers = new float[5];
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1) {
            Pressed();
            if (endpoint)
            {
                timers[levelIndex] = Time.time - timers[levelIndex];
                Debug.Log("Timer stopped");
                Debug.Log("TIME: " + timers[levelIndex]);
                
                Debug.Log("New maze started");
                levelIndex++;
            }
            if (!endpoint)
            {
                timers[levelIndex] = Time.time;
                Debug.Log("Timer started");
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