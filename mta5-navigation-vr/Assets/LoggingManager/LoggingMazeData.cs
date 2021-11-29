using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class LoggingMazeData : MonoBehaviour
{
    
    private LoggingManager loggingManager;
    private FinalFreqDire finalFreqDire;
    private FinalFreqDis finalFreqDis;
    private FinalTempDire finalTempDire;
    private FinalTempDis finalTempDis;
    private PhysicsButton buttonData;
    //private VariableHandler variableHandler;

    public GameObject player;
    private string csvFileName = "Maze";
    private int placeholder = 420;
    
    // Condition Booleans
    private bool conditionFinalFreqDire = true;
    private bool conditionFinalFreqDis = false;
    private bool conditionFinalTempDire = false;
    private bool conditionFinalTempDis = false;
    private bool conditionControlGroup = false;

    void Start()
    {
        loggingManager = GameObject.Find("Logging").GetComponent<LoggingManager>();
        finalFreqDire = GameObject.Find("forward").GetComponent<FinalFreqDire>();
        finalFreqDis = GameObject.Find("forward").GetComponent<FinalFreqDis>();
        finalTempDire = GameObject.Find("forward").GetComponent<FinalTempDire>();
        finalTempDis = GameObject.Find("forward").GetComponent<FinalTempDis>();
    }
    
    void Update()
    {
        if (conditionFinalFreqDire)
        {
            logDataCondition1();
            finalFreqDire.enabled = true;
            finalFreqDis.enabled = false;
            finalTempDire.enabled = false;
            finalTempDis.enabled = false;
        }

        if (conditionFinalFreqDis)
        {
            logDataCondition2();
            finalFreqDire.enabled = false;
            finalFreqDis.enabled = true;
            finalTempDire.enabled = false;
            finalTempDis.enabled = false;
            
        }

        if (conditionFinalTempDire)
        {
            logDataCondition3();
            finalFreqDire.enabled = false;
            finalFreqDis.enabled = false;
            finalTempDire.enabled = true;
            finalTempDis.enabled = false;
            
        }

        if (conditionFinalTempDis)
        {
            logDataCondition4();
            finalFreqDire.enabled = false;
            finalFreqDis.enabled = false;
            finalTempDire.enabled = false;
            finalTempDis.enabled = true;
            
        }

        
        
        if (Input.GetKey("space"))
        {
            loggingManager.SaveLog(csvFileName);
            loggingManager.ClearLog(csvFileName);
            loggingManager.NewFilestamp();
            print("CSV was saved");
        }
    }

    void logDataCondition1()
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
    
    void logDataCondition2()
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
    
    void logDataCondition3()
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
    
    void logDataCondition4()
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
    
    void logDataConditionControlGroup()
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
