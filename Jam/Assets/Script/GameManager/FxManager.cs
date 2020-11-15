using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public static FxManager fxm;

    public List<GameObject> fx = new List<GameObject>();

    void Awake()
    {
        fxm = this;
    }

    public void InstantiateFx(Vector3 pos,int index)
    {
        Instantiate(fx[index], pos,Quaternion.identity);
    }
}
