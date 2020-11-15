using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiMeteoreBehaviour : MonoBehaviour
{
    EnnemiBehaviour ennemi;
    public float speed;

    void Start()
    {
        ennemi = gameObject.GetComponent<EnnemiBehaviour>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (PlayerStats.stats.canTakeDamage == true)
            {
                PlayerStats.stats.TakeDamage(1);
            }
            ennemi.Die();
        }

    }
}
