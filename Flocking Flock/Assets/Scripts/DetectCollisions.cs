using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject playerBird;

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject); // TODO: Destroy the obstacle when extra hit or modify/move it
        if (other.gameObject == playerBird)
        {
            Debug.LogWarning("GAME OVER!");
        } else {
            Destroy(other.gameObject);
        }
    }
}
