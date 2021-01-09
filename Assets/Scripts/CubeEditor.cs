using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1f, 20f)]
    
    [SerializeField] TextMesh textMesh;


   
    Waypoint waypoint;
    void Awake()
    {

        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
 
        // if it is 6 for ex it becomes .6 then round to 1 then becomes 10
        //if it is 4 for ex it comes .4 then round 0 then becomes 0

    }

    

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
 
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize, 
            0f,
            waypoint.GetGridPos().y * gridSize
        );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        textMesh = transform.GetComponentInChildren<TextMesh>();
        string textLabel = waypoint.GetGridPos().x 
            + "," 
            + waypoint.GetGridPos().y ; 
        textMesh.text = textLabel;
        this.name = textLabel;
    }
}
