using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayerScoreScript; 
    
    private void Start()
    {
        displayerScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<displayerScoreScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        displayerScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
