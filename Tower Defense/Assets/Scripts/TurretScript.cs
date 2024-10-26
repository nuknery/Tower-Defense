using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Transform target;
    [SerializeField]
    private float range = 2f;
    private float turnSpeed = 10f;

    [Header("Shoot settings")]
    [SerializeField] 
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] gunBarrel;
    [SerializeField]
    private float rechargeTime;
    private int currentBarrelIndex = 0;

    private List<Transform> targetsInRange = new List<Transform>();

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (target != null)
        {
            Quaternion look = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, turnSpeed);
        }
    }

    private Transform FindTarget()
    {
        if (targetsInRange == null) return null;

        RemoveNullObjects();

        Transform newTarget = targetsInRange.First();
    
        foreach (Transform t in targetsInRange)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, t.position);
            float distanceToPrevEnemy = Vector3.Distance(transform.position, newTarget.position);
            if (distanceToEnemy < distanceToPrevEnemy)
            {
                StopCoroutine(Shoot());
                StartCoroutine(Shoot());
                newTarget = t;

            }
        }
        return newTarget;
    }

    private void RemoveNullObjects()
    {
        var nullObjects = new List<Transform>();
        foreach (Transform t in targetsInRange)
        {
            if (t == null)
            {
                nullObjects.Add(t);
            }
        }
        foreach (Transform t in nullObjects)
        {
            targetsInRange.Remove(t);
        }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitUntil(() => target != null);
            if (IsTargetLocked())
            {
                GameObject bullet = Instantiate(bulletPrefab, gunBarrel[currentBarrelIndex].position, Quaternion.identity);

                BulletScript bulletScript = bullet.GetComponent<bulletScript>();
                bulletScript.Target = target;

                currentBarrelIndex++;
                if (currentBarrelIndex == gunBarrel.Length)
                {
                    currentBarrelIndex = 0;
                }
            }
            yield return new WaitForSeconds(rechargeTime);
        }
    }

    private bool IsTargetLocked()
    {
        float angle = Quaternion.Angle(transform.rotation, target.rotation);
        if (angle > 80 && angle < 100)
        {
            return true;
        }
        return false;
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
            target = FindTarget();            
        }
    }
}
