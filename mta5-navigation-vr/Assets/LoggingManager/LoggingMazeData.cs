using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggingMazeData : MonoBehaviour
{
    
    private LoggingManager loggingManager;
    //private VariableHandler variableHandler;

    public GameObject player;
    private string csvFileName = "Maze";
    private int placeholder = 420;

    void Start()
    {
        loggingManager = GameObject.Find("Logging").GetComponent<LoggingManager>();
        //variableHandler = GameObject.Find("VariableHandler").GetComponent<VariableHandler>();
    }
    
    void Update()
    {
        logData();
        
        if (Input.GetKey("space"))
        {
            loggingManager.SaveLog(csvFileName);
            loggingManager.ClearLog(csvFileName);
            loggingManager.NewFilestamp();
            print("CSV was saved");
        }
    }

    void logData()
    {
        // Meta Logger
        loggingManager.Log(csvFileName, "Timestamp", placeholder);
        loggingManager.Log(csvFileName, "Sex", placeholder);
        loggingManager.Log(csvFileName, "TestID", placeholder);
        loggingManager.Log(csvFileName, "ParticipantID", placeholder);
        loggingManager.Log(csvFileName, "Age", placeholder);
        loggingManager.Log(csvFileName, "MotionSickness", placeholder);
        loggingManager.Log(csvFileName, "Maze", placeholder);
        loggingManager.Log(csvFileName, "VariableCondition", placeholder);
        loggingManager.Log(csvFileName, "Freq/Tempo", placeholder);
        loggingManager.Log(csvFileName, "Direction/Distance", placeholder);
        loggingManager.Log(csvFileName, "NewScenarioTest", placeholder);
        
        // Event Logger
        loggingManager.Log(csvFileName, "DeviceButtonClick", placeholder);
        loggingManager.Log(csvFileName, "DeviceButtonHoldTime", placeholder);
        loggingManager.Log(csvFileName, "DeviceButtonRelease", placeholder);
        loggingManager.Log(csvFileName, "StartPointButtonPress", placeholder);
        loggingManager.Log(csvFileName, "EndPointButtonPress", placeholder);
        
        // Sample Logger
        loggingManager.Log(csvFileName, "TravelDistance", placeholder);
        loggingManager.Log(csvFileName, "TimeSinceLastFrame", Time.deltaTime);
        loggingManager.Log(csvFileName, "MazeTime", placeholder);
        loggingManager.Log(csvFileName, "EvaluationTime", placeholder);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
}
