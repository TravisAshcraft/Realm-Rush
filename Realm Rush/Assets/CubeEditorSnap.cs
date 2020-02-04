using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditorSnap : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
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
        
       TextMesh textMesh = GetComponentInChildren<TextMesh>(); //this is how you find a component in a child;
        string labelText = waypoint.GetGridPos().x +
            "," + 
            waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        gameObject.name = textMesh.text; // reads the label name from the text mesh to display in the heirarchy
        
    }
}
