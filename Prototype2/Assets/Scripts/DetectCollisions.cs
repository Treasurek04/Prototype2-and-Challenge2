/*
 Treasure Keys
Prototype 2
Detect if ball collisions with dog 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();

    }

    private void OnTriggerEnter(Collider other)
    {
       
            displayScoreScript.score++;
            Destroy(other.gameObject);
            Destroy(gameObject);
       
    }
}
