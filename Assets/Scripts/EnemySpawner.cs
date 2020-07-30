using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1f, 120f)] [SerializeField] float secondsBetweenSpawns = 10f;
    [SerializeField] EnemyMovement enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
