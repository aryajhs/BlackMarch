using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Perform actions such as damaging the player, playing a sound, etc.
            Debug.Log("Player collided with obstacle.");
        }
    }
}

