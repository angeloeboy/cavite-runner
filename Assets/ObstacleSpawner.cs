using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Now an array of prefabs, not a single one
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
        // Choose a random spawn point for the obstacle's position
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = new Vector3(spawnPoints[randSpawnPoint].position.x, plane.position.y  + (plane.localScale.y / 2) , spawnPoints[randSpawnPoint].position.z);

        // Choose a random obstacle prefab from the array
        int randObstacle = Random.Range(0, obstaclePrefabs.Length);

        // Create an instance of the obstacle at the chosen location
        Instantiate(obstaclePrefabs[randObstacle], spawnPosition, Quaternion.identity);


    }
}
