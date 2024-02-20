using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
public class ObstacleData : ScriptableObject
{
    public bool[,] obstacleMap = new bool[10, 10]; // Assuming a 10x10 grid

    // Add any additional variables or methods as needed
}
