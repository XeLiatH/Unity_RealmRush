using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        LookAtEnemy();
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(target);
    }
}
