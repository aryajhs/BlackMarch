using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab; // Reference to the cube prefab
    public int gridSize = 10; // Size of the grid
    public bool[,] obstacleMap = new bool[10, 10]; // Assuming a 10x10 grid with obstacles

    public List<Vector3> FindPath(Vector3 startPos, Vector3 targetPos)
    {
        // Implement your grid-based pathfinding algorithm here
        // For demonstration, return a straight path from start to target
        List<Vector3> path = new List<Vector3>();
        path.Add(startPos);
        path.Add(targetPos);
        return path;
    }

    void Start()
    {
        GenerateGrid();
    }

 void GenerateGrid()
{
    float spacing = 1.1f; // Adjust this value to set the spacing between cubes

    for (int x = 0; x < gridSize; x++)
    {
        for (int z = 0; z < gridSize; z++)
        {
            // Calculate position with spacing
            Vector3 position = new Vector3(x * spacing, 0, z * spacing);

            // Instantiate cube with calculated position
            GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
            tile.transform.SetParent(transform); // Set the grid manager as parent
            tile.GetComponent<Tile>().position = new Vector2Int(x, z); // Set the position of the tile
        }
    }
}
}
