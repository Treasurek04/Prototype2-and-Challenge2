using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;
    private HealthSystem healthSystemScript;

    void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        if (healthSystemScript == null)
        {
            Debug.LogError("HealthSystem script not found. Please ensure there is a GameObject with the 'HealthSystem' tag and the HealthSystem script attached.");
        }
    }

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < bottomBound)
        {
            Debug.Log("Game Over!");
            if (healthSystemScript != null)
            {
                healthSystemScript.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
