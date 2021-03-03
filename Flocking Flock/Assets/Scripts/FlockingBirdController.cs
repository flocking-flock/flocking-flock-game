using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBirdController : MonoBehaviour
{
    public Transform targetBird;

    private Rigidbody rb;

    private float wingsPower;
    public float wingsPowerMin = 15.0f;
    public float wingsPowerMax = 40.0f;
    public float precision = 20.0f; // in degrees

    private Vector3 precisionEulers;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        wingsPower = Random.Range(wingsPowerMin, wingsPowerMax);
        precisionEulers = new Vector3(Random.Range(-precision, precision), Random.Range(-precision, precision), Random.Range(-precision, precision));
    }

    void FixedUpdate()
    {
        transform.LookAt(targetBird);

        transform.Rotate(precisionEulers); // Applying precision

        Debug.DrawLine(transform.position, transform.position + transform.forward * wingsPower, Color.blue);

        rb.AddForce(transform.forward * wingsPower, ForceMode.Acceleration);
    }
}
