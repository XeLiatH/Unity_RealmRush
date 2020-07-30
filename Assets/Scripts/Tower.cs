using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float range = 10f;
    [SerializeField] ParticleSystem bullets;

    Transform target;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();
        if (enemies.Length <= 0) { return; }

        Transform closestEnemy = enemies[0].transform;

        foreach (EnemyDamage testEnemy in enemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        target = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(transformA.position, transform.position);
        float distToB = Vector3.Distance(transformB.position, transform.position);

        if (distToB < distToA)
        {
            return transformB;
        }

        return transformA;
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(target);
    }

    private void ShootAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(target.position, transform.position);
        Shoot(distanceToEnemy <= range);
    }

    private void Shoot(bool active)
    {
        var emissionModule = bullets.emission;
        emissionModule.enabled = active;
    }
}
