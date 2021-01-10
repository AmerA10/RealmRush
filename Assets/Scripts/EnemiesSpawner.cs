using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMover enemy;
    [SerializeField] bool isSpawning = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemies()
    {
        while (isSpawning)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }
}
