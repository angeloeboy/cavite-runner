using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2.0f;
    public Transform plane;
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
        Vector3 spawnPosition = new Vector3(spawnPoints[randIndex].position.x, plane.position.y + (plane.localScale.y / 2) + (obstaclePrefab.transform.localScale.y / 2), spawnPoints[randIndex].position.z);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
