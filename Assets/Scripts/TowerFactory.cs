using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;

    public void AddTower(Waypoint waypoint)
    {
        int towerCount = FindObjectsOfType<Tower>().Length;
        if (towerCount < towerLimit)
        {
            InstantiateNewTower(waypoint);
        }
        else
        {
            MoveExistingTower();
        }

    }

    private void InstantiateNewTower(Waypoint waypoint)
    {
        Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        waypoint.isPlaceable = false;
    }

    private void MoveExistingTower()
    {
        Debug.Log("Maximum tower limit reached.");
    }
}
