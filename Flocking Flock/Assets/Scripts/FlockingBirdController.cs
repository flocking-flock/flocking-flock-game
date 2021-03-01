using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBirdController : MonoBehaviour
{
    public Transform targetBird;

    private Rigidbody rb;

    private float wingsPower = 33.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.LookAt(targetBird);

        rb.AddForce(transform.forward * wingsPower, ForceMode.Acceleration);
    }
}
