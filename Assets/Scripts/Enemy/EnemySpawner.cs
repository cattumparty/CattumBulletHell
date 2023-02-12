using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;


    private int enemyCount;
    private int waveNumber = 1;

    public float timeBtwnEnemySpawn;
    public float timeBtwnWaves;
    public int maxWaves;

    public Transform[] spawnPoints;

    bool spawningWave;

    bool bossSpawned;

    private int enemyIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWave(waveNumber));
        bossSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !spawningWave) {
            waveNumber++;

            if (waveNumber == maxWaves) {
                SpawnBoss();
                bossSpawned = true;
                StopCoroutine(SpawnEnemyWave(waveNumber));
            }

            if (!bossSpawned) StartCoroutine(SpawnEnemyWave(waveNumber));
        }
    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn) {
        spawningWave = true;
        yield return new WaitForSeconds(timeBtwnWaves);

        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefabs[i % enemyPrefabs.Length], spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefabs[i % enemyPrefabs.Length].transform.rotation);
            yield return new WaitForSeconds(timeBtwnEnemySpawn);
        }

        spawningWave = false;
    }

    void SpawnBoss() {
        Instantiate(bossPrefab, spawnPoints[0].position, bossPrefab.transform.rotation);
    }
}
