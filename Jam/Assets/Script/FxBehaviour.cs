using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxBehaviour : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DestroyItself());
    }

    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
