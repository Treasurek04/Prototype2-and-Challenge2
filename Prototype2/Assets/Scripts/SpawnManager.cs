using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;
    public bool gameOver = false;

    private HealthSystem healthSystemScript;

    void Start()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogError("PrefabsToSpawn array is empty. Please assign prefabs in the Inspector.");
            return;
        }

        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        if (healthSystemScript == null)
        {
            Debug.LogError("HealthSystem script not found. Please ensure there is a GameObject with the 'HealthSystem' tag and the HealthSystem script attached.");
            return;
        }

        StartCoroutine(SpawnPrefabsWithCooldown());
    }

    IEnumerator SpawnPrefabsWithCooldown()
    {
        while (!healthSystemScript.gameOver)
        {
            SpawnRandomPrefab();
            float randomDelay = Random.Range(1.5f, 3.0f);
            yield return new WaitForSeconds(randomDelay);
        }
    }

    void SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogError("No prefabs assigned to spawn. Please add prefabs to the prefabsToSpawn array.");
            return;
        }

        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        if (prefabsToSpawn[prefabIndex] == null)
        {
            Debug.LogError("Prefab at index " + prefabIndex + " is missing. Please check the prefabsToSpawn array.");
            return;
        }

        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        GameObject spawnedPrefab = Instantiate(prefabsToSpawn[prefabIndex], spawnPos, Quaternion.identity);

        if (spawnedPrefab != null)
        {
            Debug.Log("Spawned prefab at position: " + spawnPos);
        }
        else
        {
            Debug.LogError("Failed to spawn prefab.");
        }
    }
}
