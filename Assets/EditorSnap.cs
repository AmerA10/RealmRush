using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    // Start is called before the first frame update
 

    void Update()
    {
        Debug.Log("stuff");
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x/10f) * 10f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;
        // if it is 6 for ex it becomes .6 then round to 1 then becomes 10
        //if it is 4 for ex it comes .4 then round 0 then becomes 0
        Debug.Log(snapPos.x);
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
