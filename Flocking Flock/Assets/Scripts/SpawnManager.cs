using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    private float spawnDistance = -2.0f;

    public FlockingBirdController[] birdPrefabs;
    public Transform target;

    void Start()
    {
        InvokeRepeating("SpawnRandomBird", startDelay, spawnInterval);
    }

    void SpawnRandomBird()
    {
        int birdIndex = Random.Range(0, birdPrefabs.Length);
        Vector3 spawnPosition = transform.position + spawnDistance * transform.forward;
        FlockingBirdController o = Instantiate(birdPrefabs[birdIndex], spawnPosition, birdPrefabs[birdIndex].transform.rotation);
        o.targetBird = target;
    }
}
