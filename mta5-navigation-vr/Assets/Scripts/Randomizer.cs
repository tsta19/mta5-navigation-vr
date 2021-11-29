using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public int[][] mazeArray;
    private int currentIndex;
    public int n = 4;

    public int  modulusInt = 0;

    public int[] getLine(int n) {
        int array = new int[n];
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

    public int getMaze(int index) {
        int[] array = getLine(n);
        return array[index++];
    }

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
    }
}
