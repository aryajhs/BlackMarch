using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int position; // Position of the tile on the grid

    // You can add more properties as needed

    void Start()
    {
        // Example: Outputting the position of the tile when it starts
        Debug.Log("Tile position: (" + position.x + ", " + position.y + ")");
    }
}
