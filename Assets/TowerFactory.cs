using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower tower;
     Queue<Tower> towers = new Queue<Tower>();
    
    
    public void AddTower(Waypoint baseWaypoint)
    {
        // var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Count;


        if(numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void MoveExistingTower(Waypoint newBaseWaypoit)
    {
        Debug.Log("Reached max num of towers");
        Tower towerToMove = towers.Dequeue();
        towerToMove.baseWaypoint.isPlaceable = true;
        towerToMove.transform.position = newBaseWaypoit.transform.position;
        newBaseWaypoit.isPlaceable = false;
        towerToMove.baseWaypoint = newBaseWaypoit;
        towers.Enqueue(towerToMove);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower =  Instantiate(tower, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        newTower.baseWaypoint = baseWaypoint;
        towers.Enqueue(newTower);
       
        
    }
}
