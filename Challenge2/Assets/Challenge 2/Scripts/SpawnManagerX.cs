﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public DisplayScore displayScore;
    public bool gameOver = false; 

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    void Start()
    {
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
        displayScore = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();

        //healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        yield return new WaitForSeconds(3f);

        while (!gameOver)
        {

            SpawnRandomBall();
            float randomDelay = Random.Range(3.0f, 5.0f);
            yield return new WaitForSeconds(randomDelay);
        }
    }



    void SpawnRandomBall()
    {
        if (!gameOver) 
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            
            int ballIndex = Random.Range(0, ballPrefabs.Length);

            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
        }

        


    }
}

