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
    float potentialHeight;
    float topHeight;
    Vector3 distance;

    public Transform observer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSqrDistance = maxDistance * maxDistance;
    }

    void FixedUpdate()
    {
        potentialHeight = energy / (Physics.gravity.magnitude * rb.mass);
        topHeight = Mathf.Min(maxHeight, potentialHeight);
        distance = transform.position - observer.position;

        MovePlayer();
        ConstraintPlayerPosition();
    }

    void MovePlayer()
    {
        transform.LookAt(observer); // Making bird fly around the observer // FIXME: Make bird look where it flies

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float distanceInput = Input.GetAxis("Distance");

        Debug.Log("velocity: " + rb.velocity.magnitude + " horizontalInput: " + horizontalInput +
            " verticalInput: " + verticalInput + " distanceInput: " + distanceInput);

        rb.AddForce(transform.up * verticalInput * wingsPower +
            (-transform.right) * horizontalInput * wingsPower +
            transform.forward * distanceInput * wingsPower,
            ForceMode.Acceleration);
    }

    void ConstraintPlayerPosition()
    {
        if (distance.sqrMagnitude > maxSqrDistance)
        {
            transform.position = observer.position + maxDistance * distance.normalized;
        }
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
