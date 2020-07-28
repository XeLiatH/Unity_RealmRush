using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform target;
    [SerializeField] float range = 10f;
    [SerializeField] ParticleSystem bullets;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            LookAtEnemy();
            ShootAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(target);
    }

    private void ShootAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(target.transform.position, gameObject.transform.position);
        Shoot(distanceToEnemy <= range);
    }

    private void Shoot(bool active)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = active;
    }
}
