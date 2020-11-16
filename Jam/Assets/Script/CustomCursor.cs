﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public static CustomCursor cursor;
    public Vector3 targetPos;
    public Vector3 offset;

    private void Awake()
    {
        cursor = this;
    }

    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,50) + offset);
        transform.position = targetPos;
    }
}
