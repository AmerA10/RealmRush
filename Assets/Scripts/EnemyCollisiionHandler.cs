using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisiionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int maxHits = 3;
    [SerializeField] GameObject hitFX;
    [SerializeField] GameObject deathFX;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Colliding with particle");
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
    }

    private void playDamage()
    {
        GameObject hitFx = Instantiate(hitFX, transform.position, Quaternion.identity);
    }

    private void KillEnemy()
    {
        Destroy(this.gameObject);
        GameObject dyingFx = Instantiate(deathFX, transform.position, Quaternion.identity);
    }
    
}
