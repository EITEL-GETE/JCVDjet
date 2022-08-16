using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Borders")]
    public float height = 1f;

    [Header("Coin")]
    public float coinPosition;
    public float coinHeight;
    public float coinSpawnRate;
    public List<GameObject> coinPrefabs;

    [Header("Persons")]
    public float personPosition;
    public float personHeight;
    public float personSpawnRate;
    public List<GameObject> personPrefabs;

    [Header("Obstacles")]
    public float obstaclePosition;
    public float obstacleHeight;
    public float obstacleSpawnRate;
    public List<GameObject> obstaclePrefabs;

    [Header("Bonus")]
    public float bonusPosition;
    public float bonusHeight;
    public float bonusSpawnRate;
    public List<GameObject> bonusPrefabs;

    [Header("Boss")]
    public float bossPosition;
    public float bossHeight;
    public float bossSpawnRate;
    public bool isBossSpawn = false;
    public List<GameObject> bossPrefabs;

    private float coinTime, personTime, obstacleTime, bonusTime, coinTemp, personTemp, obstacleTemp, bonusTemp, bossTime, bossTemp = 0f;

    private void Update()
    {
        RunTimers();

        SpawnElement(coinPrefabs,     ref coinTime,     ref coinTemp,     coinSpawnRate,     coinPosition,     coinHeight    );
        SpawnElement(personPrefabs,   ref personTime,   ref personTemp,   personSpawnRate,   personPosition,   personHeight  );
        SpawnElement(obstaclePrefabs, ref obstacleTime, ref obstacleTemp, obstacleSpawnRate, obstaclePosition, obstacleHeight);
        SpawnElement(bonusPrefabs,    ref bonusTime,    ref bonusTemp,    bonusSpawnRate,    bonusPosition,    bonusHeight   );

        SpawnBoss(bossPrefabs,        ref bossTime,     ref bossTemp,     bossSpawnRate,      bossPosition,    bossHeight);         
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // Coins
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + coinPosition, transform.position.z), new Vector3(1, coinHeight, 0));

        Gizmos.color = Color.red; // Obstacles
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + obstaclePosition, transform.position.z), new Vector3(1, obstacleHeight, 0));

        Gizmos.color = Color.green; // Persons
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + personPosition, transform.position.z), new Vector3(1, personHeight, 0));

        Gizmos.color = Color.magenta; // Bonus
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + bonusPosition, transform.position.z), new Vector3(1, bonusHeight, 0));

        Gizmos.color = Color.blue; // Boss
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y + bonusPosition, transform.position.z), new Vector3(1, bossHeight, 0));
    }

    private void RunTimers()
    {
        coinTime += Time.deltaTime;
        personTime += Time.deltaTime;
        obstacleTime += Time.deltaTime;
        bonusTime += Time.deltaTime;
        bossTime += Time.deltaTime;
    }

    private Vector3 SpawnPosition(float position, float height)
    {
        return new Vector3(transform.position.x + Random.Range(0, 5f), position + Random.Range(0, height) - height / 2, transform.position.z);
    }

    private void SpawnElement(List<GameObject> prefabs, ref float time, ref float temp, float spawnRate, float position, float height)
    {
        if (time > spawnRate + temp)
        {
            temp = time;
            Vector3 coinPosition = SpawnPosition(position, height);
            if (prefabs.Count > 0)
                Instantiate(prefabs[Random.Range(0, prefabs.Count)], coinPosition, transform.rotation, transform);
        }
    }

    private void SpawnBoss(List<GameObject> prefabs, ref float time, ref float temp, float spawnRate, float position, float height)
    {
        if (time > spawnRate + temp)
        {
            temp = time;
            Vector3 coinPosition = new Vector3(position, height, transform.position.z);
            if (!isBossSpawn && prefabs.Count > 0)
            {
                Instantiate(prefabs[Random.Range(0, prefabs.Count)], coinPosition, transform.rotation, transform);

                isBossSpawn = true;
            }
        }   
    }
}
