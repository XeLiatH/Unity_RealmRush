using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(1f, 120f)] [SerializeField] float secondsBetweenSpawns = 10f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;

    [SerializeField] Text scoreText;

    int score = 0;

    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParent;

            score++;
            scoreText.text = score.ToString();

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
