using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    Animator animator;
    float velocity;
    public float accelaration;
    public float decceleration;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool forwardPressed = Input.GetKey("z");
        bool runPressed = Input.GetKey("left shift");

        if (forwardPressed && velocity < 1)
        {
            velocity += Time.deltaTime * accelaration;
        }

        if (!forwardPressed && velocity > 0)
        {
            velocity -= Time.deltaTime * decceleration;
        }

        if(velocity < 0)
        {
            velocity = 0;
        }
        animator.SetFloat("Velocity", velocity);
    }
}
