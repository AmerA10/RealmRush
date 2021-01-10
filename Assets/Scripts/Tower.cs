using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtEnemy();
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
