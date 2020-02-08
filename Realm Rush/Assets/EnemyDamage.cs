using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    int hitPoints = 5;
    private void OnParticleCollision(GameObject other)
    {
        print("IM HIT");
        ProcessHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
