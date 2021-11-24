using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public int[][] mazeArray;
    private int currentIndex;

    public void Randomize()
    {
        currentIndex = Random.Range(0, (mazeArray.Length - 1));
        if (mazeArray[currentIndex][1] == 0)
        {
            WayPointChecker.MazeID = mazeArray[currentIndex][0];
        }
        else
        {
            Randomize();
        }
    }
}
