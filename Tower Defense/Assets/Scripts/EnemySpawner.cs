using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float countdown = 3f;
    [SerializeField]
    private float timeBetweenSpawnEnemy = 1f;

    private int waveNumber = 1;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(countdown);
        for (int i = 0; i < waveNumber; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            obj.transform.parent = transform;
            yield return new WaitForSeconds(timeBetweenSpawnEnemy);
        }
        waveNumber++;
        StartCoroutine(SpawnWave());
    }
}
