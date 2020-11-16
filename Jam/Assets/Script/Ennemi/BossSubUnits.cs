using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSubUnits : MonoBehaviour
{
    public float health = 30;
    public BossBehavior boss;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        FxManager.fxm.InstantiateFx(transform.position, 0);
        boss.subUnits.Remove(gameObject);
        Destroy(gameObject);
    }
}
