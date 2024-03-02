using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float obstacleSpeed = 3f;
    public float obstacleGap = 10f;
    private float nextObstacleTime = 0f;

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.InProgress)
        {
            if (Time.time >= nextObstacleTime)
            {
                SpawnObstacle();
                nextObstacleTime = Time.time + obstacleGap;
            }
        }
    }

    void SpawnObstacle()
    {
        float obstacleYPosition = Random.Range(-3f, 4.5f);
        Vector3 spawnPosition = new Vector3(transform.position.x + 40, obstacleYPosition, 0f);
        int randNum = Random.Range(0, obstaclePrefabs.Length);
        GameObject newObstacle = Instantiate(obstaclePrefabs[randNum], spawnPosition, Quaternion.identity);
        Rigidbody2D obstacleRigidbody = newObstacle.GetComponent<Rigidbody2D>();
        obstacleRigidbody.velocity = new Vector2(-obstacleSpeed, 0f);
        Destroy(newObstacle, 22f);
    }
}
