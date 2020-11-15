using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 bulletDir;

    private void Start()
    {
        StartCoroutine(DestroyItself());
    }

    void Update()
    {
        transform.Translate(bulletDir * speed * Time.deltaTime);
    }

    public void setDirAndSpeed(float newSpeed, Vector3 dir)
    {
        bulletDir = dir;
        speed = newSpeed;
    }

    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
