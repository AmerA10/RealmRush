using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float moveTime = 2f;
    [SerializeField] ParticleSystem deathFX;
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
            yield return new WaitForSeconds(moveTime); //gives us control for one second and comes back
        }
        SelfDestruct();
        //reached end, deal damage to player
    }

    private void SelfDestruct()
    {

        ParticleSystem dyingFx = Instantiate(deathFX, transform.position, Quaternion.identity);
        dyingFx.Play();
        Destroy(dyingFx.gameObject, dyingFx.main.duration);
        Destroy(this.gameObject);

    }
}



