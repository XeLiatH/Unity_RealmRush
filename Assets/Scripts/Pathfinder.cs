using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
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
        ExploreNeighbours();
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

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinate = startWaypoint.GetGridPosition() + direction;
            if (grid.ContainsKey(explorationCoordinate))
            {
                grid[explorationCoordinate].SetTopColor(Color.blue);
            }
        }
    }
}
