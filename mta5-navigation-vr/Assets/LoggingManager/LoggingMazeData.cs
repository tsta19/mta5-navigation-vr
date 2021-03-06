using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LoggingMazeData : MonoBehaviour
{
    private float oldPosX;
    private float oldPosZ;
    private float newPosX;
    private float newPosZ;
    private LoggingManager loggingManager;
    private FinalFreqDire finalFreqDire;
    private FinalFreqDis finalFreqDis;
    private FinalTempDire finalTempDire;
    private FinalTempDis finalTempDis;
    private PhysicsButton buttonData;

    public static bool isDone = false;
    public static bool isMoving = false;
    //private VariableHandler variableHandler;
    
    public string Sex;
    public int TestID;
    public int Age;
    public bool MotionSickness;
    public int VariableCondition;
    public string FreqTemp;
    public string DirecDist;
    
    
    public GameObject player;
    public GameObject device;
    private string csvFileName = "Maze";
    private int placeholder = 420;
    
    // Condition Booleans
    public bool conditionFinalFreqDire = false;
    public bool conditionFinalFreqDis = false;
    public bool conditionFinalTempDire = false;
    public bool conditionFinalTempDis = false;
    public bool conditionControlGroup = false;

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
        
        loggingManager.Log(csvFileName, "TrialID", WayPointChecker.MazeTag);
        
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
        
        if (conditionControlGroup)
        {
            logDataConditionControlGroup();
            finalFreqDire.enabled = false;
            finalFreqDis.enabled = false;
            finalTempDire.enabled = false;
            finalTempDis.enabled = false;
        }
        
        loggingManager.Log(csvFileName, "IsMoving", isMoving);
        loggingManager.Log(csvFileName, "PlayerRotationX", player.transform.rotation.x);
        loggingManager.Log(csvFileName, "PlayerRotationY", player.transform.rotation.y);
        loggingManager.Log(csvFileName, "PlayerRotationZ", player.transform.rotation.z);
        loggingManager.Log(csvFileName, "DeviceRotationX", device.transform.rotation.x);
        loggingManager.Log(csvFileName, "DeviceRotationY", device.transform.rotation.y);
        loggingManager.Log(csvFileName, "DeviceRotationZ", device.transform.rotation.z);

        if (Player_Teleportation.isForceTP)
        {
            loggingManager.Log(csvFileName, "isForceTP", Player_Teleportation.isForceTP);
            Player_Teleportation.isForceTP = false;
        }
        else
        {
            loggingManager.Log(csvFileName, "isForceTP", Player_Teleportation.isForceTP);
        }

        if (Randomizer.idfk > 3 && isDone==false || Input.GetKey("space"))
        {
            loggingManager.SaveLog(csvFileName);
            loggingManager.ClearLog(csvFileName);
            loggingManager.NewFilestamp();
            print("CSV was saved");
            isDone = true;
        }
    }

    void logDataCondition1()
    {
        // Meta Logger
        loggingManager.Log(csvFileName, "Sex", Sex);
        loggingManager.Log(csvFileName, "TestID", TestID);
        loggingManager.Log(csvFileName, "Age", Age);
        loggingManager.Log(csvFileName, "MotionSickness", MotionSickness);
        loggingManager.Log(csvFileName, "MazeID", WayPointChecker.MazeID);
        loggingManager.Log(csvFileName, "VariableCondition", VariableCondition);
        loggingManager.Log(csvFileName, "Freq/Tempo", FreqTemp);
        loggingManager.Log(csvFileName, "Direction/Distance", DirecDist);

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
        loggingManager.Log(csvFileName, "EvaluationTime", Time.time);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
    
    void logDataCondition2()
    {
        // Meta Logger
        loggingManager.Log(csvFileName, "Sex", Sex);
        loggingManager.Log(csvFileName, "TestID", TestID);
        loggingManager.Log(csvFileName, "Age", Age);
        loggingManager.Log(csvFileName, "MotionSickness", MotionSickness);
        loggingManager.Log(csvFileName, "MazeID", WayPointChecker.MazeID);
        loggingManager.Log(csvFileName, "VariableCondition", VariableCondition);
        loggingManager.Log(csvFileName, "Freq/Tempo", FreqTemp);
        loggingManager.Log(csvFileName, "Direction/Distance", DirecDist);
        
        
        // Event Logger
        loggingManager.Log(csvFileName, "DeviceButtonClickStart", finalFreqDis.deviceButtonClickStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerStart", finalFreqDis.deviceButtonClickTimerStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerSpent", finalFreqDis.deviceButtonClickTimerSpentHolder);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerEnd", finalFreqDis.deviceButtonClickTimerEnd);
        loggingManager.Log(csvFileName, "DeviceButtonClickStop", finalFreqDis.deviceButtonClickStop);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerTotal", finalFreqDis.deviceButtonClickTimerTotal);
        loggingManager.Log(csvFileName, "StartPointButtonPress", PhysicsButton.startButtonPressd);
        loggingManager.Log(csvFileName, "EndPointButtonPress", PhysicsButton.endButtonPressd);
        loggingManager.Log(csvFileName, "ToggleOnID", finalFreqDis.toggleOnID);
        loggingManager.Log(csvFileName, "ToggleOffID", finalFreqDis.toggleOffID);
        
        
        
        // Sample Logger
        loggingManager.Log(csvFileName, "TravelDistance", distanceCalc.totalDistance);
        loggingManager.Log(csvFileName, "TimeSinceLastFrame", Time.deltaTime);
        loggingManager.Log(csvFileName, "MazeTime", PhysicsButton.timers[PhysicsButton.levelIndex]);
        loggingManager.Log(csvFileName, "EvaluationTime", Time.time);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
    
    void logDataCondition3()
    {
        // Meta Logger
        loggingManager.Log(csvFileName, "Sex", Sex);
        loggingManager.Log(csvFileName, "TestID", TestID);
        loggingManager.Log(csvFileName, "Age", Age);
        loggingManager.Log(csvFileName, "MotionSickness", MotionSickness);
        loggingManager.Log(csvFileName, "MazeID", WayPointChecker.MazeID);
        loggingManager.Log(csvFileName, "VariableCondition", VariableCondition);
        loggingManager.Log(csvFileName, "Freq/Tempo", FreqTemp);
        loggingManager.Log(csvFileName, "Direction/Distance", DirecDist);
        
        // Event Logger
        loggingManager.Log(csvFileName, "DeviceButtonClickStart", finalTempDire.deviceButtonClickStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerStart", finalTempDire.deviceButtonClickTimerStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerSpent", finalTempDire.deviceButtonClickTimerSpentHolder);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerEnd", finalTempDire.deviceButtonClickTimerEnd);
        loggingManager.Log(csvFileName, "DeviceButtonClickStop", finalTempDire.deviceButtonClickStop);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerTotal", finalTempDire.deviceButtonClickTimerTotal);
        loggingManager.Log(csvFileName, "StartPointButtonPress", PhysicsButton.startButtonPressd);
        loggingManager.Log(csvFileName, "EndPointButtonPress", PhysicsButton.endButtonPressd);
        loggingManager.Log(csvFileName, "ToggleOnID", finalTempDire.toggleOnID);
        loggingManager.Log(csvFileName, "ToggleOffID", finalTempDire.toggleOffID);
        
        // Sample Logger
        loggingManager.Log(csvFileName, "TravelDistance", distanceCalc.totalDistance);
        loggingManager.Log(csvFileName, "TimeSinceLastFrame", Time.deltaTime);
        loggingManager.Log(csvFileName, "MazeTime", PhysicsButton.timers[PhysicsButton.levelIndex]);
        loggingManager.Log(csvFileName, "EvaluationTime", Time.time);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
    
    void logDataCondition4()
    {
        // Meta Logger
        loggingManager.Log(csvFileName, "Sex", Sex);
        loggingManager.Log(csvFileName, "TestID", TestID);
        loggingManager.Log(csvFileName, "Age", Age);
        loggingManager.Log(csvFileName, "MotionSickness", MotionSickness);
        loggingManager.Log(csvFileName, "MazeID", WayPointChecker.MazeID);
        loggingManager.Log(csvFileName, "VariableCondition", VariableCondition);
        loggingManager.Log(csvFileName, "Freq/Tempo", FreqTemp);
        loggingManager.Log(csvFileName, "Direction/Distance", DirecDist);
        
        // Event Logger
        loggingManager.Log(csvFileName, "DeviceButtonClickStart", finalTempDis.deviceButtonClickStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerStart", finalTempDis.deviceButtonClickTimerStart);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerSpent", finalTempDis.deviceButtonClickTimerSpentHolder);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerEnd", finalTempDis.deviceButtonClickTimerEnd);
        loggingManager.Log(csvFileName, "DeviceButtonClickStop", finalTempDis.deviceButtonClickStop);
        loggingManager.Log(csvFileName, "DeviceButtonClickTimerTotal", finalTempDis.deviceButtonClickTimerTotal);
        loggingManager.Log(csvFileName, "StartPointButtonPress", PhysicsButton.startButtonPressd);
        loggingManager.Log(csvFileName, "EndPointButtonPress", PhysicsButton.endButtonPressd);
        loggingManager.Log(csvFileName, "ToggleOnID", finalTempDis.toggleOnID);
        loggingManager.Log(csvFileName, "ToggleOffID", finalTempDis.toggleOffID);
        
        // Sample Logger
        loggingManager.Log(csvFileName, "TravelDistance", distanceCalc.totalDistance);
        loggingManager.Log(csvFileName, "TimeSinceLastFrame", Time.deltaTime);
        loggingManager.Log(csvFileName, "MazeTime", PhysicsButton.timers[PhysicsButton.levelIndex]);
        loggingManager.Log(csvFileName, "EvaluationTime", Time.time);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
    
    void logDataConditionControlGroup()
    {
        // Meta Logger
        loggingManager.Log(csvFileName, "Sex", Sex);
        loggingManager.Log(csvFileName, "TestID", TestID);
        loggingManager.Log(csvFileName, "Age", Age);
        loggingManager.Log(csvFileName, "MotionSickness", MotionSickness);
        loggingManager.Log(csvFileName, "MazeID", WayPointChecker.MazeID);
        loggingManager.Log(csvFileName, "VariableCondition", VariableCondition);
        loggingManager.Log(csvFileName, "Freq/Tempo", FreqTemp);
        loggingManager.Log(csvFileName, "Direction/Distance", DirecDist);
        
        // Event Logger
        loggingManager.Log(csvFileName, "StartPointButtonPress", PhysicsButton.startButtonPressd);
        loggingManager.Log(csvFileName, "EndPointButtonPress", PhysicsButton.endButtonPressd);
        
        // Sample Logger
        loggingManager.Log(csvFileName, "TravelDistance", distanceCalc.totalDistance);
        loggingManager.Log(csvFileName, "TimeSinceLastFrame", Time.deltaTime);
        loggingManager.Log(csvFileName, "MazeTime", PhysicsButton.timers[PhysicsButton.levelIndex]);
        loggingManager.Log(csvFileName, "EvaluationTime", Time.time);
        loggingManager.Log(csvFileName, "PlayerPositionX", player.transform.position.x);
        loggingManager.Log(csvFileName, "PlayerPositionY", player.transform.position.y);
        loggingManager.Log(csvFileName, "PlayerPositionZ", player.transform.position.z);
        
        // loggingManager.Log(csvFileName, "VarName", placeholder); - Template for more variables
    }
}
