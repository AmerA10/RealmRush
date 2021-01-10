using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameter
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem gun;

    //state of each tower
    Transform targetEnemy;

    /*
     * Recipe for suerlatives
     * 1. Get the collections of things
     * Assume the first is the "winner"
     * For each item in the collection
     *     --Update the Winner
     * Return winner regardless of foreach
     */


    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        
        if(targetEnemy)
        {
            LookAtEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
      
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyCollisiionHandler>();
        if(sceneEnemies.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyCollisiionHandler testEnemy in sceneEnemies)
        {
            //check distance
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float disToA = Vector3.Distance(transformA.position, this.transform.position);
        float disToB = Vector3.Distance(transformB.position, this.transform.position);
        if (disToA > disToB) {
            return transformB;
        }
        else
        {
            return transformA;
        }
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.position, this.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
            Debug.Log("Shooting: " + distanceToEnemy);
        }
        else
        {
            Shoot(false);
            Debug.Log("Not Shooting: " + distanceToEnemy);
        }
    }


    private void Shoot(bool isActive)
    {
        ParticleSystem.EmissionModule emissionModule = gun.emission;
        emissionModule.enabled = isActive;
    }
    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
