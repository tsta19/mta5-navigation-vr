using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Randomizer : MonoBehaviour
{
    public GameObject[] mazes;
    public int  modulusInt = 0;
    public static int levelIndex = 0;
    public int mazeAmount;
    public static int idfk = 0;

    public int[] getLine(int n) {
        int[] array = new int[n];
        int k = (modulusInt - 1) % 4;
        
        for(int i = 0; i < n; i++)
        {
            k++;
            if (k > n) {
                k = 1;
            }
            array[i] = k;
        }
        return array;
    }

    public void updateMaze() {
        int[] array = getLine(mazeAmount);
        
        
        //if (PhysicsButton.firstPress)
        //{
        
        //}
        WayPointChecker.MazeID = array[idfk];

        if (WayPointChecker.MazeID == 1)
        {
            FinalTempDis.arrayIndex = 3;
        }
        if (WayPointChecker.MazeID == 2)
        {
            FinalTempDis.arrayIndex = 11;
        }
        if (WayPointChecker.MazeID == 3)
        {
            FinalTempDis.arrayIndex = 18;
        }
        if (WayPointChecker.MazeID == 4)
        {
            FinalTempDis.arrayIndex = 33;
        }

        //int[] array = getLine(mazeAmount);
    }

    public GameObject getMaze() {

        int[] array = getLine(mazeAmount);
        int mazeIndex = array[idfk];
        return mazes[mazeIndex - 1];
    }

    /*int[][] mazeArray;
    int currentIndex;
    public void Randomize()
    {
        currentIndex = Random.Range(0, (mazeArray.Length - 1));
        if (mazeArray[currentIndex][1] == 0)
        {
            WayPointChecker.MazeID = mazeArray[currentIndex][0];
            Debug.Log("MazeID: " + WayPointChecker.MazeID);
        }
        else
        {
            Randomize();
        }
    }*/
}
