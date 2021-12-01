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
        
        print("MAZEID: " + array[idfk]);
        
        if (PhysicsButton.firstPress)
        {
            WayPointChecker.MazeID = array[idfk];
        }
        
        for (int i = 0; i < array.Length; i++)
        {
            print("sokakok" + array[i]);
        }
        print("array:" + array);
        

        //int[] array = getLine(mazeAmount);
    }

    public GameObject getMaze() {

        int[] array = getLine(mazeAmount);
        int mazeIndex = array[idfk];
        print("mazearray: " + array);
        print("mazeindex: " + mazeIndex);
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
