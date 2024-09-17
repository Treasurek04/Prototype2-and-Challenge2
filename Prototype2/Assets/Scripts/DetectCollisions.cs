using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        GameObject scoreObject = GameObject.FindGameObjectWithTag("DisplayScoreText");
        if (scoreObject != null)
        {
            displayScoreScript = scoreObject.GetComponent<DisplayScore>();
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'DisplayScoreText' found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (displayScoreScript != null)
        {
            displayScoreScript.score++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("DisplayScore script not found. Make sure the GameObject with the 'DisplayScoreText' tag has a DisplayScore component.");
        }
    }
}
