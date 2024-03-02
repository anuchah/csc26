using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnerBackground : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float obstacleGap = 10f;
    private float nextObstacleTime = 0f;

    void Update()
    {
        if (Time.time >= nextObstacleTime)
        {
            SpawnObstacle();
            nextObstacleTime = Time.time + obstacleGap;
        }
    }

    void SpawnObstacle()
    {
        float obstacleYPosition = Random.Range(0, 2f);
        Vector3 spawnPosition = new Vector3(transform.position.x + 15, obstacleYPosition, 0f);
        int randNum = Random.Range(0, obstaclePrefabs.Length);
        GameObject newObstacle = Instantiate(obstaclePrefabs[randNum], spawnPosition, Quaternion.identity);
        Destroy(newObstacle, 5f);
    }
}
