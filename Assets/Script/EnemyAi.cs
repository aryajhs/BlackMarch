using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyAI : MonoBehaviour, AI
{
    public GridManager gridManager; // Reference to the grid manager
    private bool isMoving = false;
    private Vector3 targetPosition;

    public void MoveTowardsPlayer(Vector3 playerPosition)
    {
        if (!isMoving)
        {
            // Calculate the adjacent tile closest to the player
            targetPosition = CalculateClosestAdjacentTile(playerPosition);

            // Calculate path to the target position using pathfinding algorithm
            List<Vector3> path = gridManager.FindPath(transform.position, targetPosition);

            // Move the enemy towards the target position along the calculated path
            StartCoroutine(MoveAlongPath(path));
        }
    }

    private Vector3 CalculateClosestAdjacentTile(Vector3 playerPosition)
    {
        // Implement logic to find the closest adjacent tile to the player
        // For simplicity, you can choose one of the adjacent tiles based on distance
        // For example, choose the tile to the right if it's closer, otherwise choose the tile to the left
        return playerPosition + Vector3.right;
    }

    IEnumerator MoveAlongPath(List<Vector3> path)
    {
        isMoving = true;
        foreach (Vector3 waypoint in path)
        {
            while (transform.position != waypoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint, Time.deltaTime * 5f);
                yield return null;
            }
        }
        isMoving = false;
    }
}
