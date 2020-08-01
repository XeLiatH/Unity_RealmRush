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
    [SerializeField] AudioClip spawnEnemySFX;

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

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(spawnEnemySFX);

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
