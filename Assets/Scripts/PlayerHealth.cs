using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int playerHealth = 10;
    [SerializeField] int healthDecrease = 1;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        playerHealth -= healthDecrease;
    }
}
