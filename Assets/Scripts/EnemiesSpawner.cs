using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemiesSpawner : MonoBehaviour
{

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMover enemy;
    [SerializeField] bool isSpawning = true;
    [SerializeField] Text scoreText;
    [SerializeField] int scorePerEnemy = 1;
    private int score = 0;

    [SerializeField] AudioClip spawnedEnemySFX;

    

    // Start is called before the first frame update
    void Start()
    {


        scoreText.text = score.ToString();
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
            Instantiate(enemy, transform.position, Quaternion.identity, this.transform);
            IncreaseScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    private void IncreaseScore()
    {
        score += scorePerEnemy;
        scoreText.text = score.ToString();
    }
}
