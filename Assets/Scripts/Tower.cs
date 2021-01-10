using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem gun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
