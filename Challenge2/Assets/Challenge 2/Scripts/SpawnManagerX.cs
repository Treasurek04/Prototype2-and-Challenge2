using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;  

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    void SpawnRandomBall()
    {
        if (ballPrefabs.Length == 0)
        {
            Debug.LogError("Ball prefabs array is empty. Please assign ball prefabs in the Inspector.");
            return;
        }

        int randomIndex = Random.Range(0, ballPrefabs.Length);  // Get a random index
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        Instantiate(ballPrefabs[randomIndex], spawnPos, Quaternion.identity);  // Spawn the ball
    }
}
