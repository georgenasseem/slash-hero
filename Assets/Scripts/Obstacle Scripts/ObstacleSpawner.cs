using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject spikePrefab, swingingObstaclePrefab, wolfPrefab;

    [SerializeField]
    private GameObject[] rotatingObstaclePrefabs;

    [SerializeField]
    private float spikeYPos = -3.5f;

    [SerializeField]
    private float wolfYPos = -3.1f;

    [SerializeField]
    private float rotatingObstacleMinY = -3.3f, rotatingObstacleMaxY = -0.6f;

    [SerializeField]
    private float swingObstacleMinY = 0.7f, swingObstacleMaxY = 3f;

    [SerializeField]
    private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;

    private float spawnWaitTime;

    private int obstacleTypesCount = 4;

    private int obstacleToSpawn;

    private Camera mainCam;

    private Vector3 obstacleSpawnPos = Vector2.zero;

    private GameObject newObstacle;

    [SerializeField]
    private GameObject healthPrefab;

    [SerializeField]
    private float minHealthY = -3.3f, maxHealthY = 1f;

    private Vector3 healthSpawnPos = Vector3.zero;

    [SerializeField]
    private int healthSpawnProbability = 6;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        HandleObstacleSpawning();
    }

    void HandleObstacleSpawning()
    {

        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
            SpawnObstacle();
            SpawnHealth();
        }

    }

    void SpawnObstacle()
    {

        obstacleToSpawn = Random.Range(0, obstacleTypesCount);

        obstacleSpawnPos.x = mainCam.transform.position.x + 20f;

        switch (obstacleToSpawn)
        {
            case 0:
                newObstacle = Instantiate(spikePrefab);
                obstacleSpawnPos.y = spikeYPos;
                break;

            case 1:
                newObstacle = Instantiate(swingingObstaclePrefab);
                obstacleSpawnPos.y = Random.Range(swingObstacleMinY, swingObstacleMaxY);
                break;

            case 2:
                newObstacle = Instantiate(wolfPrefab);
                obstacleSpawnPos.y = wolfYPos;
                break;

            case 3:
                newObstacle = Instantiate
                    (rotatingObstaclePrefabs[Random.Range(0, rotatingObstaclePrefabs.Length)]);
                obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;

    }

    void SpawnHealth()
    {
        if (Random.Range(0, 11) > healthSpawnProbability)
        {
            healthSpawnPos.x = mainCam.transform.position.x + 30f;
            healthSpawnPos.y = Random.Range(minHealthY, maxHealthY);
            Instantiate(healthPrefab, healthSpawnPos, Quaternion.identity);
        }
    }

} // class

























