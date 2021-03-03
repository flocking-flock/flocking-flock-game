using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxHeight = 15.0f;
    private float minHeight = 0.0f;
    private float energy = 150.0f; // of something !!!
    private float wingsPower = 30.0f;
    private float maxDistance = 20.0f;
    private float maxSqrDistance;

    public Transform observer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSqrDistance = maxDistance * maxDistance;
    }

    void FixedUpdate()
    {
        transform.LookAt(observer); // Making bird fly around the observer // FIXME: Make bird look where it flies

        float potentialHeight = energy / (Physics.gravity.magnitude * rb.mass);
        float topHeight = Mathf.Min(maxHeight, potentialHeight);
        float potentialEnergy = rb.mass * transform.position.y * Physics.gravity.magnitude;
        float kineticEnergy = energy - potentialEnergy;
        float speed = Mathf.Sqrt(2 * kineticEnergy / rb.mass);
        Vector3 distance = transform.position - observer.position;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log("velocity: " + rb.velocity.magnitude + " potentialHeight: " + potentialHeight + " horizontalInput: " + horizontalInput + " verticalInput: " + verticalInput + " distance: " + distance.magnitude);

        rb.AddForce(transform.up * verticalInput * wingsPower + (-transform.right) * horizontalInput * wingsPower, ForceMode.Acceleration);

        keepMaxDistance(distance);
        keepHeight(topHeight);
    }

    void keepMaxDistance(Vector3 distance)
    {
        if (distance.sqrMagnitude > maxSqrDistance)
        {
            transform.position = observer.position + maxDistance * distance.normalized;
        }
    }

    void keepHeight(float topHeight)
    {
        if (transform.position.y > topHeight)
        {
            transform.position = new Vector3(transform.position.x, topHeight, transform.position.z);
        }
        if (transform.position.y < minHeight)
        {
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
        }
    }
}
