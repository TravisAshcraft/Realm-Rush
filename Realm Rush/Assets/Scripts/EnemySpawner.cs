using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPoint;
    float timeBetweenSpawns = 4f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBetweenSpawns);
        GameObject enemyClone = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;
    }
}
