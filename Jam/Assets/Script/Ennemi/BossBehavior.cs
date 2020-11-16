using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public float health = 200f;
    public float speed;

    public float attackCooldown, fireRate;

    public List<GameObject> subUnits = new List<GameObject>();
    public GameObject bullet, rocket;

    void Start()
    {
        
    }
    void Update()
    {
        if (transform.position.z < PlayerController.control.MainCamTransform.position.z + 40)
        {
            if (Time.time >= attackCooldown)
            {
                attackCooldown = Time.time + 1f / fireRate;
                SelectAttack();
            }
        }
        else
        {
            MoveTowardPlayer();
        }
    }

    void MoveTowardPlayer()
    {

        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }

    void SelectAttack()
    {
        int randomSelection = Random.Range(0, 3);

        if(randomSelection == 0 && subUnits.Count > 0)
        {
            StartCoroutine(SubUnitsShoot());
        }
        if(randomSelection == 1 && subUnits.Count > 0)
        {
            StartCoroutine(SubUnitsAllOutShoot());
        }
        if(randomSelection == 2 || subUnits.Count <= 0)
        {
            StartCoroutine(RocketLaunch());
        }
    }

    IEnumerator SubUnitsShoot()
    {
        for (int i = 0; i < subUnits.Count; i++)
        {
            FxManager.fxm.InstantiateFx(subUnits[i].transform.GetChild(0).gameObject.transform.position, 1);
            GameObject newBullet = Instantiate(bullet, subUnits[i].transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
            newBullet.GetComponent<EnnemiBulletBehaviour>().setDirAndSpeed(2, PlayerController.control.pos - subUnits[i].transform.GetChild(0).gameObject.transform.position);
            yield return new WaitForSeconds(0.4f);
        }
    }

    IEnumerator SubUnitsAllOutShoot()
    {
        for (int i = 0; i < subUnits.Count; i++)
        {
            FxManager.fxm.InstantiateFx(subUnits[i].transform.GetChild(0).gameObject.transform.position, 1);
            GameObject newBullet = Instantiate(bullet, subUnits[i].transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
            newBullet.GetComponent<EnnemiBulletBehaviour>().setDirAndSpeed(2, PlayerController.control.pos - subUnits[i].transform.GetChild(0).gameObject.transform.position);
        }
        yield return null;
    }

    IEnumerator RocketLaunch()
    {
        for(int i = 0; i < 3; i++)
        {
            FxManager.fxm.InstantiateFx(transform.position, 1);
            GameObject newBullet = Instantiate(rocket, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        } 
    }
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
        FxManager.fxm.InstantiateFx(transform.position,5);
        gameOverUI.gameOver.ActivateVictory();
        Destroy(gameObject);
    }
}
