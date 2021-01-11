using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update




    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();

        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    IEnumerator FollowPath(List<Waypoint> path)
    {
       
        foreach (Waypoint waypoint in path)//loops here
        {
            transform.position = waypoint.transform.position;
          
            yield return new WaitForSeconds(2f); //gives us control for one second and comes back
        }

      

    }
}



