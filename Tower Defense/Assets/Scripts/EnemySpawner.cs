using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 1f);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform);
    }
}
