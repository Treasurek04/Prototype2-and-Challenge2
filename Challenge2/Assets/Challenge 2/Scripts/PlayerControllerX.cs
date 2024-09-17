/*
 Treasure Keys
Challenge 2
Controls for player 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float waitTime = 2;
    public float timeCount = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > waitTime)

        {
            timeCount = Time.time * waitTime;

            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
