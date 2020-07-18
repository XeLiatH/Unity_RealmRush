using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;

    void Start()
    {
        foreach (Block waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
