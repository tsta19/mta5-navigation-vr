using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggingMazeData : MonoBehaviour
{
    
    private LoggingManager loggingManager;
    private FinalFreqDire finalFreqDire;
    private PhysicsButton buttonData;
    //private VariableHandler variableHandler;

    public GameObject player;
    private string csvFileName = "Maze";
    private int placeholder = 420;

    void Start()
    {
        loggingManager = GameObject.Find("Logging").GetComponent<LoggingManager>();
        finalFreqDire = GameObject.Find("forward").GetComponent<FinalFreqDire>();
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
        loggingManager.Log(csvFileName, "MazeID", placeholder);
        loggingManager.Log(csvFileName, "VariableCondition", placeholder);
        loggingManager.Log(csvFileName, "Freq/Tempo", placeholder);
        loggingManager.Log(csvFileName, "Direction/Distance", placeholder);
        loggingManager.Log(csvFileName, "NewScenarioTest", placeholder);
        
        // Event Logger
        loggingManager.Log(csvFileName, "DeviceButtonClickStart", finalFreqDire.deviceButtonClickStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerStart", finalFreqDire.deviceButtonClickTimerStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerSpent", finalFreqDire.deviceButtonClickTimerSpentHolder);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerEnd", finalFreqDire.deviceButtonClickTimerEnd);
        loggingManager.Log(csvFileName, "DeviceButtonClickStop", finalFreqDire.deviceButtonClickStop);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerTotal", finalFreqDire.deviceButtonClickTimerTotal);
        loggingManager.Log(csvFileName, "StartPointButtonPress", PhysicsButton.startButtonPressd);
        loggingManager.Log(csvFileName, "EndPointButtonPress", PhysicsButton.endButtonPressd);
        loggingManager.Log(csvFileName, "ToggleOnID", finalFreqDire.toggleOnID);
        loggingManager.Log(csvFileName, "ToggleOffID", finalFreqDire.toggleOffID);
        
        // Sample Logger
        loggingManager.Log(csvFileName, "TravelDistance", distanceCalc.totalDistance);
        loggingManager.Log(csvFileName, "TimeSinceLastFrame", Time.deltaTime);
        loggingManager.Log(csvFileName, "MazeTime", PhysicsButton.timers[PhysicsButton.levelIndex]);
        loggingManager.Log(csvFileName, "EvaluationTime", placeholder);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
}
