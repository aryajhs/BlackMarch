using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab;

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        
        
        if (obstacleData == null)
        {
            Debug.LogError("ObstacleData is not assigned in ObstacleManager!");
            return;
        }
        Debug.Log("Generating obstacles...");

        for (int x = 0; x < obstacleData.obstacleMap.GetLength(0); x++)
        {
            for (int y = 0; y < obstacleData.obstacleMap.GetLength(1); y++)
            {
                if (obstacleData.obstacleMap[x, y])
                {
                    Vector3 obstaclePosition = new Vector3(x, 0.5f, y);
                    Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
                }
                
            
                 
            
            }
        }
    }
}