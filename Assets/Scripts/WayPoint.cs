using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2Int gridPos;
    const int gridSize = 10;

    public bool isExplored = false; //ok as is a data class

    public Waypoint exploredFrom; //ok because it is data class
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse on: " + this.transform.name);
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) ,
            Mathf.RoundToInt(transform.position.z / gridSize) 
        );
    }


}
