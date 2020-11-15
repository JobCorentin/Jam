using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiStrikerBehaviour : MonoBehaviour
{
    EnnemiBehaviour ennemi;
    public float speed;

    public bool followCircle;
    private float angle = 0;
    public float radius = 2;

    public int type;
    Transform target;
    bool targetSet = false;
    public bool followWaypoints;
    public int wavePointIndex = 0;

    public float attackCooldown;
    public float fireRate;
    public float damage;
    public GameObject bullet;
    public Transform shootPoint;


    void Start()
    {
        ennemi = gameObject.GetComponent<EnnemiBehaviour>();
    }

    void Update()
    {
        if (transform.position.z < PlayerController.control.MainCamTransform.position.z + 40)
        {
            if (followWaypoints)
                FollowWaypoints();
            else if (followCircle)
                CircleMovement();

            if(Time.time >= attackCooldown)
            {
                attackCooldown = Time.time + 1f / fireRate;
                Attack();
            }

        }
        else
        {
            MoveTowardPlayer();
        }
    }
    #region Movement

    void MoveTowardPlayer()
    {

        transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }

    void CircleMovement() 
    {
        float x = 0;
        float y = 0;

        x = radius * Mathf.Cos(angle);
        y = radius * Mathf.Sin(angle);

        transform.Translate(new Vector3(x, y) * speed * Time.deltaTime);

        angle += 1 * Time.deltaTime;
    }

    void FollowWaypoints()
    {

        if (type == 1 && targetSet == false)
        {
            targetSet = true;
            target = WayPoints.way.rectanglePattern[0];
        }
        else if (type == 2 && targetSet == false)
        {
            targetSet = true;
            target = WayPoints.way.trianglePattern[0];
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)
            {
                GetNextWayPoint();
            }
    }

    void GetNextWayPoint()
    {
        if(type == 1)
        {
            if (wavePointIndex >= WayPoints.way.rectanglePattern.Length - 1)
            {
                wavePointIndex = 0;
            }
            else
            {
                wavePointIndex++;
            }
            target = WayPoints.way.rectanglePattern[wavePointIndex];
        }
        else if (type == 2)
        {
            if (wavePointIndex >= WayPoints.way.trianglePattern.Length - 1)
            {
                wavePointIndex = 0;
            }
            else
            {
                wavePointIndex++;
            }
            target = WayPoints.way.trianglePattern[wavePointIndex];
        }
       
    }
    #endregion

    void Attack()
    {
        FxManager.fxm.InstantiateFx(shootPoint.position, 1);
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<EnnemiBulletBehaviour>().setDirAndSpeed(1, PlayerController.control.pos - transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if(PlayerStats.stats.canTakeDamage == true)
            {
                PlayerStats.stats.TakeDamage(1);
            }
            ennemi.Die();
        }

    }
}
