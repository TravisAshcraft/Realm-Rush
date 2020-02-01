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
           waypoint.GetGridPos().x,
            0f, 
            waypoint.GetGridPos().y
         );
    }

    private void UpdateLabel()
    {
        
       TextMesh textMesh = GetComponentInChildren<TextMesh>(); //this is how you find a component in a child;
        int gridSize = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x/ gridSize +
            "," + 
            waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = textMesh.text; // reads the label name from the text mesh to display in the heirarchy
    }
}
