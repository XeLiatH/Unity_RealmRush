using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting patrol ...");

        foreach (Waypoint waypoint in path)
        {
            Debug.Log("Visiting block: " + waypoint.name);
            gameObject.transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("Ending patrol ...");
    }
}
