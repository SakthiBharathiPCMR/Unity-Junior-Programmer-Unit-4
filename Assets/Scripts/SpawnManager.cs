using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemeyPrefabs;
    public GameObject poweupPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            if (waveNumber > 1)
            {
                SpawnPowerup();
            }

        }

    }

    private void SpawnPowerup()
    {
        Instantiate(poweupPrefabs, GenerateSpawnPosition(), poweupPrefabs.transform.rotation);
    }

    private void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemeyPrefabs, GenerateSpawnPosition(), enemeyPrefabs.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0f, spawnPosZ);
        return randomPos;
    }


}

