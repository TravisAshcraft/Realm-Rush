using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Waypoint searchCenter;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    bool isRunning = true;
    Vector2Int[] directions =
    { 
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    }; 
    
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbors();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
        print("Finished pathfinding?");
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            print("searching from end node, therefore stopping");// todo remove later;
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return; }
        foreach ( Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbour(neighbourCoordinates);
            }
            catch
            {
                //do nothing
            }
            
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.blue);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            bool isOverLapping = grid.ContainsKey(gridPos);
            if (isOverLapping)
            {
                Debug.LogWarning("Overlapping Block" + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
