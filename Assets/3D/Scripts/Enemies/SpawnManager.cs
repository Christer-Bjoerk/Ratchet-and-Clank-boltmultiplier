using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Suggestion: Make an list and spawn enemies at random spawn points
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private bool canSpawn = true;

    private float timer;

    private ObjectPoolManager poolManager;

    private void Start()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // Spawn enemies
        if (canSpawn && timer >= spawnInterval)
        {
            // Event?
            SpawnEnemy();
            timer = 0;
        }
    }

    public void SpawnEnemy()
    {
        GameObject enemy = poolManager.GetGameObject(enemyPrefab);
        enemy.transform.SetPositionAndRotation(spawnPoint.position, Quaternion.identity);
    }
}
