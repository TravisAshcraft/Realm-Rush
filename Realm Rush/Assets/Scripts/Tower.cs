using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem projectileParticle;
    float attackRange = 30f;

    //state of each tower
    Transform targetEnemy;
    Transform towerBlock;
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
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


    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>(); //Get the coledction of things
        if (sceneEnemies.Length == 0) { return; }
        Transform closestEnemy = sceneEnemies[0].transform; //Assume the first is the "winner"
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if(distToA < distToB)
        {
            return transformA;
        }

        return transformB;
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
