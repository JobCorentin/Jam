using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static WayPoints way;

    public GameObject rectangle, triangle;

    public Transform[] rectanglePattern; 
    public Transform[] trianglePattern;

    private void Awake()
    {
        way = this;
        rectanglePattern = new Transform[rectangle.transform.childCount];
        for (int i = 0; i < rectanglePattern.Length; i++)
        {
            rectanglePattern[i] = rectangle.transform.GetChild(i);
        }

        trianglePattern = new Transform[triangle.transform.childCount];
        for (int i = 0; i < rectanglePattern.Length -1; i++)
        {
            trianglePattern[i] = triangle.transform.GetChild(i);
        }
    }
}
