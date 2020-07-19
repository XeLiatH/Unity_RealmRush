using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Dictionary<Vector2Int, Waypoint> trail = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    
    // todo: directions should be in the enemy ??
    // todo: also enemy should be able to find its own path

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    void Start()
    {
        LoadWaypoints();
        ColorStartAndEnd();
        FindPath();
    }

    private void LoadWaypoints()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPosition();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Waypoint " + waypoint.name + " is overlapping. Skipping ...");
                continue;
            }

            grid.Add(gridPos, waypoint);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.yellow);
    }

    private void FindPath()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            Waypoint searchCenter = queue.Dequeue();
            if (searchCenter == endWaypoint)
            {
                break;
            }

            ExploreNeighbours(searchCenter);
        }

        List<Waypoint> path = new List<Waypoint>();

        Waypoint wp = endWaypoint;

        path.Add(wp);

        bool done = false;
        while (!done)
        {
            var back = trail[wp.GetGridPosition()];
            path.Add(back);

            wp = back;

            if (back == startWaypoint)
            {
                done = true;
            }
        }

        path.Reverse();

        foreach (Waypoint waypoint in path)
        {
            waypoint.SetTopColor(Color.yellow);
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinate = from.GetGridPosition() + direction;
            if (grid.ContainsKey(explorationCoordinate) && !trail.ContainsKey(explorationCoordinate))
            {
                Waypoint neighbour = grid[explorationCoordinate];

                queue.Enqueue(neighbour);
                trail[explorationCoordinate] = from;
            }
        }
    }
}
