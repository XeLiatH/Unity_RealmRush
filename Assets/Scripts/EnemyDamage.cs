using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem hitVFXPrefab;
    [SerializeField] ParticleSystem deathVFXPrefab;
    [SerializeField] int hitPoints = 10;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnParticleCollision(GameObject other)
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
        audioSource.PlayOneShot(hitSFX);
    }

    void KillEnemy()
    {
        var vfx = Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
        vfx.Play();

        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);

        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
