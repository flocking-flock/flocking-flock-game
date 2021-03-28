using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject); // TODO: Destroy the obstacle when extra hit or modify/move it
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("GAME OVER!");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
