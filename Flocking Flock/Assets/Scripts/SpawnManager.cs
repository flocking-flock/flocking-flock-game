using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    private float spawnDistance = -2.0f;
    private float targetVelocityThreshold = 2.0f;
    private float sqrTargetVelocityThreshold;
    private int packCount = 2;

    public FlockingBirdController[] birdPrefabs;
    public Transform target;
    public Rigidbody targetRigidBody;

    void Start()
    {
        sqrTargetVelocityThreshold = targetVelocityThreshold * targetVelocityThreshold;
        InvokeRepeating("SpawnRandomBird", startDelay, spawnInterval);
    }

    void SpawnRandomBird()
    {
        // New birds fly in when target bird flies to the left or to the right of the screen
        if (targetRigidBody.velocity.sqrMagnitude > sqrTargetVelocityThreshold)
        {
            for (int i = 0; i < packCount; i++)
            {
                int birdIndex = Random.Range(0, birdPrefabs.Length);
                Vector3 spawnPosition = transform.position + spawnDistance * transform.forward;
                FlockingBirdController o = Instantiate(birdPrefabs[birdIndex], spawnPosition, birdPrefabs[birdIndex].transform.rotation);
                o.targetBird = target;
                o.targetBirdRigidBody = targetRigidBody;
            }
        }
    }
}
