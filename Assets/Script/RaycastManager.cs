using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    public Text infoText; // Reference to the UI text element

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Tile tile = hit.collider.GetComponent<Tile>();
            if (tile != null)
            {
                // Display the tile's position on the UI element
                infoText.text = "Tile Position: (" + tile.position.x + ", " + tile.position.y + ")";
            }
        }
    }
}
