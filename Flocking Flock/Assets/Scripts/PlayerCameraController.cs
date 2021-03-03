using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform playerBird;
    public float smoothSpeed = 0.1f;

    void FixedUpdate()
    {
        Vector3 direction = playerBird.transform.position - transform.position;
        Debug.DrawLine(transform.position, playerBird.transform.position, Color.magenta);

        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, smoothSpeed);
    }
}
