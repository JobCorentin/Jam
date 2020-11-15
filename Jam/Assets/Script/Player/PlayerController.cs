using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController control;

    public Transform MainCamTransform;
    public Transform shootPoint;

    //Movement related
    [SerializeField] float movementSpeed;
    [SerializeField] private float speedSmoothVelocity;
    [SerializeField] private float speedSmoothTime;
    float currentSpeed;
    public Vector3 pos;

    //Shoot Related
    [SerializeField] float shotCooldown;
    [SerializeField] float fireRate;
    [SerializeField] float range;
    [SerializeField] float damage;
    [SerializeField] Vector3 fxOffset = new Vector3(0,0,-2);
    public GameObject Bullets;

    CharacterController controller;

    void Awake()
    {
        control = this;
        controller = GetComponent<CharacterController>();
        MainCamTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Move();
        if (Input_Listener.inp.rightClick == true && Time.time >= shotCooldown)
        {
            shotCooldown = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    void Move()
    {
        Vector3 movementDir = Input_Listener.inp.DirectionInput;
        pos = transform.position;

        float targetSpeed = movementSpeed * movementDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
        controller.Move(movementDir * currentSpeed * Time.deltaTime);

        if (transform.position.x < MainCamTransform.position.x - 3)
        {
            pos = new Vector3(-3,transform.position.y,transform.position.z);
            transform.position = pos;
        }
        else if(transform.position.x > MainCamTransform.position.x + 3)
        {
            pos = new Vector3(3, transform.position.y,transform.position.z);
            transform.position = pos;
        }

        if(transform.position.y < MainCamTransform.position.y - 2)
        {
            pos = new Vector3(transform.position.x,-2,transform.position.z);
            transform.position = pos;
        }
        else if(transform.position.y > MainCamTransform.position.y + 2)
        {
            pos = new Vector3(transform.position.x,2,transform.position.z);
            transform.position = pos;
        }
    }

    void Shoot()
    {
        RaycastHit hit;


        FxManager.fxm.InstantiateFx(shootPoint.position, 1);
        GameObject newBullet = Instantiate(Bullets, transform.position, Quaternion.identity);
        newBullet.GetComponent<BulletBehaviour>().setDirAndSpeed(10, CustomCursor.cursor.targetPos - transform.position);

        if (Physics.Raycast(transform.position, CustomCursor.cursor.targetPos - transform.position, out hit, range))
            {
                EnnemiBehaviour target = hit.transform.GetComponent<EnnemiBehaviour>();
                if(target != null)
                {
                FxManager.fxm.InstantiateFx(hit.point + fxOffset, 2);
                target.TakeDamage(damage);
                }
            }

    }
}
