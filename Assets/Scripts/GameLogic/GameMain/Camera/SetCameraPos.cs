﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraPos : MonoBehaviour
{
    public GameObject _Camera;
    public float BackwardOffset = 2f;
    public float HeightOffset = 5f;
    public float HorizontalOffset;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vector = gameObject.GetComponent<GridSystem>().FindCubeCell(new VectorInGame(gameObject.GetComponent<GridSystem>().Center().X,0)).transform.position;
        vector.z -= BackwardOffset;
        vector.y += HeightOffset;
        vector.x += HorizontalOffset;
        _Camera.transform.position = vector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
