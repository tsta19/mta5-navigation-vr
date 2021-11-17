using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class directionScript : MonoBehaviour
{
    public Vector3 _directionVector;
    public Transform objective;
    public float angle;
    public AudioSource[] audioSources;
    public AudioSource sonar1;
    public AudioSource sonar2;
    public AudioSource sonar3;
    public AudioSource sonar4;
    public AudioSource sonar5;
    public float angleRelativeToObjective;
    public int level = 5;
    public float holder;
    public float timerLimit;
    public float timer;
    public bool startTimer;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("stordiller");
        //Fetch the AudioSource from the GameObject
        audioSources = GetComponents<AudioSource>();
        Debug.Log("lillediller");
        sonar2 = audioSources[1];
        /*sonar1 = audioSources[0];
        sonar3 = audioSources[2];
        sonar4 = audioSources[3];
        sonar5 = audioSources[4];*/
        holder = Mathf.Abs(angle);
        Debug.Log("diller" + audioSources.Length);
        startTimer = true;
        timerLimit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Button1"))
        {
            Debug.Log("dafaq" + audioSources.Length);
            sonar2.Play();
            sonar2.loop = true;
        }
        
        if(startTimer)
        {
            timer += Time.deltaTime;
            if(timer >= timerLimit)
            {
                startDetection();
                timer = 0f;
            }
        }
    }

    void startDetection()
    {
        _directionVector = objective.transform.position - transform.position;
        angle = Vector3.SignedAngle(_directionVector, transform.forward, Vector3.forward);
        level = Mathf.CeilToInt(angle / 18);
        if (Mathf.Abs(holder) != Mathf.Abs(angle))
        {
            if (level < 6)
            {
                Debug.Log(level);
                Debug.Log(audioSources.Length);

                sonar1 = audioSources[level-1];
                sonar1.Play();
                holder = angle;
            }
            else
            {
                sonar5.Play();
            }
        }
        
        
    }
    
}

