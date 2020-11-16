using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiRocketBehaviour : MonoBehaviour
{
    public float speed;
    public float health;
    public Vector3 bulletDir;

    private void Start()
    {
        StartCoroutine(DestroyItself());
    }

    void Update()
    {
        bulletDir = (PlayerController.control.pos - transform.position).normalized;
        transform.Translate(bulletDir * speed * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            DestroyOnContact();
        }
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
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
    void DestroyOnContact()
    {
        FxManager.fxm.InstantiateFx(transform.position, 0);
        Destroy(gameObject);

    }
}
