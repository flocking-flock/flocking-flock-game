using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxHeight = 15.0f;
    private float minHeight = 0.0f;
    private float maxRight = 10.0f;
    private float maxLeft = -10.0f;
    private float energy = 150.0f; // of something !!!
    private float wingsPower = 30.0f;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float potentialHeight = energy / (Physics.gravity.magnitude * rb.mass);
        float topHeight = Mathf.Min(maxHeight, potentialHeight);
        float potentialEnergy = rb.mass * transform.position.y * Physics.gravity.magnitude;
        float kineticEnergy = energy - potentialEnergy;
        float speed = Mathf.Sqrt(2 * kineticEnergy / rb.mass);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log("potentialHeight: " + potentialHeight + " horizontalInput: " + horizontalInput + " verticalInput: " + verticalInput);

        rb.AddForce(transform.up * verticalInput * wingsPower + transform.right * horizontalInput * wingsPower, ForceMode.Acceleration);

        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);

        
    }

    // Update is called once per frame
    void Update()
    {
        float potentialHeight = energy / (Physics.gravity.magnitude * rb.mass);
        float topHeight = Mathf.Min(maxHeight, potentialHeight);

        if (transform.position.x > maxRight)
        {
            transform.position = new Vector3(maxRight, transform.position.y, transform.position.z);
        }
        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y, transform.position.z);
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
