using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1f, 20f)]
    [SerializeField] float gridSize = 10f;
    [SerializeField] TextMesh textMesh;

    void Awake()
    {
        Debug.Log("start");
        textMesh = transform.Find("Top").GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        Debug.Log("stuff");
        Vector3 snapPos;
        textMesh = transform.GetComponentInChildren<TextMesh>();
     
        snapPos.x = Mathf.RoundToInt(transform.position.x/ gridSize) * gridSize; //basically makes any value either a multiple of 10 or 0
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        textMesh.text = snapPos.x/gridSize + "," + snapPos.z/gridSize;
        // if it is 6 for ex it becomes .6 then round to 1 then becomes 10
        //if it is 4 for ex it comes .4 then round 0 then becomes 0
        
    }
}
