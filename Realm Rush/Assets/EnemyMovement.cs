using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

   IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting path");
        foreach(Waypoint waypoint in path) //calling the list Block renaming it waypoint in the path 
        {
            print(waypoint);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("End of path");
    }
}
