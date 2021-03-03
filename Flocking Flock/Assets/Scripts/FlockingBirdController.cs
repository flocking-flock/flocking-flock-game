using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingBirdController : MonoBehaviour
{
    public Transform targetBird;
    public Rigidbody targetBirdRigidBody;

    private Rigidbody rb;

    private float wingsPower;
    public float wingsPowerMin = 15.0f;
    public float wingsPowerMax = 40.0f;
    public float precision = 30.0f; // in degrees
    private float smoothSpeed = 0.8f; // TODO: Make a random range on each update

    public float closeRange = 0.1f; // The range (of velocity of the target) that the bird is scared to be close

    private Vector3 precisionEulers;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        wingsPower = Random.Range(wingsPowerMin, wingsPowerMax);
        precisionEulers = new Vector3(Random.Range(-precision, precision), Random.Range(-precision, precision), Random.Range(-precision, precision));
    }

    void FixedUpdate()
    {
        Vector3 direction = targetBird.transform.position - transform.position;
        Debug.DrawLine(transform.position, targetBird.transform.position, Color.magenta);

        if (direction.sqrMagnitude < closeRange * targetBirdRigidBody.velocity.sqrMagnitude)
        {
            // "Scared" of collision
            direction = -direction;
        }

        // Look at
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, smoothSpeed);
        Debug.DrawLine(transform.position, transform.position + transform.forward * wingsPower, Color.red);

        // Applying precision
        transform.Rotate(precisionEulers);
        Debug.DrawLine(transform.position, transform.position + transform.forward * wingsPower, Color.blue);

        rb.AddForce(transform.forward * wingsPower, ForceMode.Acceleration);
    }
}
