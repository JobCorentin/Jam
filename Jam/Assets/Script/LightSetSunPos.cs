using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetSunPos : MonoBehaviour
{

    void Start()
    {
        Shader.SetGlobalVector("_SunDirection", transform.forward);
    }
}
