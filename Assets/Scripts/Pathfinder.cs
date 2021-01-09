using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    // Start is called before the first frame update

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter; //the currentSearch center
    Vector2Int[] directions = { 


        Vector2Int.up, //up
        Vector2Int.right, //right
        Vector2Int.down, //down
        Vector2Int.left //left

    };
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Color startColor;
    [SerializeField] Waypoint endWaypoint;
    [SerializeField] Color endColor;


    void Start()
    {
        LoadBlocks();
        SetStartEndWayPointColor();
        Pathfind();

    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while(queue.Count > 0 && isRunning)
        {

            searchCenter = queue.Dequeue();//where the search happenes
            searchCenter.isExplored = true;
            
            HaltIfEndFound();
            ExploreNeighbours();
      
        }

        //todo workout path
        Debug.Log("Finished path finding..?");
    }

    private void HaltIfEndFound()
    {
        if(searchCenter == endWaypoint)
        {
            searchCenter.SetTopColor(Color.red);
          
            isRunning = false;
                
        }
    }

    private void ExploreNeighbours()
    {
        if(!isRunning)
        {
            return;
        }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                //do nothing
            }
           
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        
        if (!neighbour.isExplored && !queue.Contains(neighbour))
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
            
           
        }

        
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();//finds everything of that type in the scene, must be enabled
        foreach(Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos); //checks if the grid already contains this key
            if (isOverlapping)
            {
           
            }
            else
            {
                grid.Add(gridPos, waypoint);//adding to dictionary
               
            }
           
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SetStartEndWayPointColor()
    {
        startWaypoint.SetTopColor(startColor);
        endWaypoint.SetTopColor(endColor);
    }
}
