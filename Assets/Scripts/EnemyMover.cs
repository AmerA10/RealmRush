using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
       // Debug.Log("im back at start"); //unity does other stuff in between coroutine times
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    void Update()
    {
        
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
       // Debug.Log("Starting Patrol");
        foreach (Waypoint waypoint in path)//loops here
        {
            transform.position = waypoint.transform.position;
          //  Debug.Log("Visiting Blocks: " + waypoint.name);
            yield return new WaitForSeconds(1f); //gives us control for one second and comes back
        }

       // Debug.Log("Ending Patrol");

    }
}

    // Update is called once per frame


