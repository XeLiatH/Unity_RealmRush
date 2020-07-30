using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    List<Waypoint> path = new List<Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left,
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count <= 0)
        {
            CalculatePath();
        }

        return path;
    }

    private void CalculatePath()
    {
        LoadWaypoints();
        BreadthFirstSearch();
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

    private void BreadthFirstSearch()
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
    }

    private void FindPath()
    {
        Waypoint prev = endWaypoint.exploredFrom;

        path.Add(endWaypoint);
        while (prev != startWaypoint)
        {
            path.Add(prev);
            prev = prev.exploredFrom;
        }
        path.Add(startWaypoint);

        path.Reverse();
    }

    private void ExploreNeighbours(Waypoint from)
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinate = from.GetGridPosition() + direction;
            if (grid.ContainsKey(explorationCoordinate))
            {
                Waypoint neighbour = grid[explorationCoordinate];

                if (null == neighbour.exploredFrom)
                {
                    queue.Enqueue(neighbour);
                    neighbour.exploredFrom = from;
                }
            }
        }
    }
}
