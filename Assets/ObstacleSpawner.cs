using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2.0f;

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnObstacle()
    {
        int randIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(obstaclePrefab, spawnPoints[randIndex].position, Quaternion.identity);
    }
}
