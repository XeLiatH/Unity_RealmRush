using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem hitVFXPrefab;
    [SerializeField] ParticleSystem deathVFXPrefab;
    [SerializeField] int hitPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints--;
        hitVFXPrefab.Play();
    }

    void KillEnemy()
    {
        var p = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        p.Play();

        Destroy(gameObject);
    }
}
