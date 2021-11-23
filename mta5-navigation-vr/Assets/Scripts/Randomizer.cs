using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public int[][] mazeArray;
    private int currentIndex;
    public int mazeID;

    void Randomize()
    {
        currentIndex = Random.Range(0, mazeArray.Length);
        if (mazeArray[currentIndex][1] == 0)
        {
            mazeID = mazeArray[currentIndex][0];
        }
        else
        {
            Randomize();
        }
    }
}
