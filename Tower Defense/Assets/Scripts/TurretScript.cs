using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float range = 2f;

    private List<Transform> targetsInRange = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        //InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    private void FindTarget()
    {
        if (targetsInRange == null) return;
        float distance = 0;

        foreach (Transform t in targetsInRange)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, t.position);
            if (distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                target = t;
            }
        }

        if (distance > range)
        {
            target = null;
            return;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            targetsInRange.Add(col.transform);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            targetsInRange.Remove(col.transform);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy")
        {
            FindTarget();            
        }
    }
}
