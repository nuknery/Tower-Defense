using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Emeny : MonoBehaviour
{
    private Vector3 finishPoint;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private EnemyData enemyData;

    private uint health;

    private void Awake()
    {
        finishPoint = GameObject.FindGameObjectWithTag("Finish").transform.position;
    }

    private void Start()
    {
        agent.destination = finishPoint;
        agent.speed = enemyData.speed;
        health = enemyData.maxHealth;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
