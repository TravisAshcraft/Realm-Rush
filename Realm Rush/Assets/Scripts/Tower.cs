using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] ParticleSystem projectileParticle;
    float attackRange = 30f;

    // Update is called once per frame
    void Update()
    {
        if (!targetEnemy)
        {
            Shoot(false);
            return;
        }
        else
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
       
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position); // creates the distance var between the enemy and the tower
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
