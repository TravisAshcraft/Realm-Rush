﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditorSnap : MonoBehaviour
{
    [SerializeField][Range(1f,20f)]float gridSize = 10f;

    TextMesh textMesh;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 snapPos;
        
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>(); //this is how you find a component in a child;
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}