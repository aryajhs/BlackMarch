using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GridManager gridManager;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;
                List<Vector3> path = gridManager.FindPath(transform.position, targetPosition);
                if (path != null)
                {
                    StartCoroutine(MoveAlongPath(path));
                }
            }
        }
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
