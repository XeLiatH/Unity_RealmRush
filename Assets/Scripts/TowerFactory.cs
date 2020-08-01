using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParent;

    Queue<Tower> buffer = new Queue<Tower>();

    public void AddTower(Waypoint waypoint)
    {
        int towerCount = FindObjectsOfType<Tower>().Length;
        if (towerCount < towerLimit)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveExistingTower(waypoint);
        }

    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        var tower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        tower.transform.parent = towerParent;

        tower.baseWaypoint = waypoint;
        waypoint.isPlaceable = false;

        buffer.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint waypoint)
    {
        var oldTower = buffer.Dequeue();

        waypoint.isPlaceable = false;
        oldTower.baseWaypoint.isPlaceable = true;

        oldTower.transform.position = waypoint.transform.position;
        oldTower.baseWaypoint = waypoint;

        buffer.Enqueue(oldTower);
    }
}
