using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats stats;

    public int health;
    public bool canTakeDamage = true;

    void Awake()
    {
        stats = this;
    }

    public void TakeDamage(int damage)
    {
        if(canTakeDamage == true)
        {
            canTakeDamage = false;

            health -= damage;
            UIManager.ui.SetHealtbarValue();
            StartCoroutine(DamagePostProcess());
            SimpleCameraShakeInCinemachine.camShake.Shake(1f, 2f);
            if(health <= 0)
            {
                FxManager.fxm.InstantiateFx(transform.position, 4);
            }
            else
            {
                FxManager.fxm.InstantiateFx(transform.position, 3);
            }
        }
        if(health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Timer(1f));
        }
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
    }

    public void Die()
    {
        gameOverUI.gameOver.ActivateGameOver();
        gameObject.SetActive(false);
    }

    public IEnumerator DamagePostProcess()
    {
        PostProcessManager.post.ActivatePostProcess(0);
        yield return new WaitForSeconds(1f);
        PostProcessManager.post.DeactivatePostProcess();
    }
}
