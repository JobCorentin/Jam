using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    Animator animator;
    float velocity;
    public float acceleration;
    public float deceleration;
    public float maxSpeed = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input_Listener.inp.LeftJoystickInput.magnitude > 0.1f)
        {
            if (velocity < maxSpeed)
                velocity += Input_Listener.inp.LeftJoystickInput.magnitude * Time.deltaTime * acceleration;
            else if (velocity >= maxSpeed)
                velocity = maxSpeed;
        }
        else if(Input_Listener.inp.LeftJoystickInput.magnitude < 0.1f)
        {
            if(velocity > 0)
            velocity -= Time.deltaTime * deceleration;
            else if (velocity <= 0)
            {
                velocity = 0;
            }
        }

        animator.SetFloat("VelocityZ", velocity);

    }
}
