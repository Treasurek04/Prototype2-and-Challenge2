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

    public HealthSystem healthSystem;

    void Start()
    {
        healthSystem = gameOverObject.FindGameObjectWithTag("HealthSystem").GetCompenent<healthSystem>();
        if (prefabsToSpawn.Length == 0)
        {
            Debug.LogError("PrefabsToSpawn array is empty. Please assign prefabs in the Inspector.");
            return;
        }
        StartCoroutine(SpawnPrefabsWithCooldown());
    }

    IEnumerator SpawnPrefabsWithCooldown()
    {
        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();
            float randomDelay = Random.Range(1.5f, 3.0f);

            yield return new WaitForSeconds(3f); // Wait for 3 seconds between spawns
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
