using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisiionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHits = 3;
    [SerializeField] ParticleSystem hitFX;
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] AudioClip enemyHurtSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    [SerializeField] Transform cameraPos;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if (maxHits <= 0)
        {
            KillEnemy();
        }
        else
        {
            playDamage();
        }
    }

    private void ProcessHit()
    {
        maxHits--;
        GetComponent<AudioSource>().PlayOneShot(enemyHurtSFX);
    }

    private void playDamage()
    {
        hitFX.Play();
        
    }

    private void KillEnemy()
    {
       
        ParticleSystem dyingFx = Instantiate(deathFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, cameraPos.position, 100f);
        
        dyingFx.Play();
        Destroy(dyingFx.gameObject, dyingFx.main.duration);
        Destroy(this.gameObject);
        
    }
    
}
