using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehaviour : MonoBehaviour
{
    public float health = 50;

    public void TakeDamage( float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        FxManager.fxm.InstantiateFx(transform.position, 0);
        GameManager.game.RemoveFromList(gameObject);
        Destroy(gameObject);
    }
}
