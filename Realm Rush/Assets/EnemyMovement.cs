using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;
    float delayMove = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrintAllWaypoints());
    }

    IEnumerator PrintAllWaypoints()
    {
        print("Starting path");
        foreach(Block waypoint in path) //calling the list Block renaming it waypoint in the path 
        {
            print(waypoint);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(delayMove);
        }
        print("End of path");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
