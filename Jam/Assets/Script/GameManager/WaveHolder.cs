using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHolder : MonoBehaviour
{
    public static WaveHolder wave;

    public List<GameObject> rectangleWave1, triangleWave1, circleWave1;
    public List<GameObject> rectangleWave2, triangleWave2, circleWave2;
    public List<GameObject> rectangleWave3, triangleWave3, circleWave3;
    void Awake()
    {
        wave = this;
    }
}
