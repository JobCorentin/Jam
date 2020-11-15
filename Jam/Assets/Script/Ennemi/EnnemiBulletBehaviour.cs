using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBulletBehaviour : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (PlayerStats.stats.canTakeDamage == true)
            {
                PlayerStats.stats.TakeDamage(1);
            }
            DestroyOnContact();
        }

    }

    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
     void DestroyOnContact()
    {
        Destroy(gameObject);
    }
}
