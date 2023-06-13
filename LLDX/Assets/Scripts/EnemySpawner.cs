using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 2.0f;
    public int minEnemiesToSpawn = 5;
    public int maxEnemiesToSpawn = 5;

    private float spawnInterval;
    private float timeSinceLastSpawn;

    private void Start()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnMultipleEnemies();
            timeSinceLastSpawn = 0f;

            // スポーン間隔
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnMultipleEnemies()
    {
        // ランダムスポーン
        int enemiesToSpawn = Random.Range(minEnemiesToSpawn, maxEnemiesToSpawn);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), transform.position.y, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}