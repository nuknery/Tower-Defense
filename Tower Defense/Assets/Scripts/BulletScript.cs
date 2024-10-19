using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private float speed = 10f;

    private int damage = 10;

    private Transform target;

    public Transform Transform
    {
        set
        {
            target = value;
            TakeForce(target);
            transform.LookAt(target);
        }
    }

    private void Awake()
    {
        
    }

    private void Update()
    {

    }

    public void TakeForce(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            //col.Componenet<Enemy>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
