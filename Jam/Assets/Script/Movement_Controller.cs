using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Controller : MonoBehaviour
{
    public static Movement_Controller mov;

    [SerializeField] float movementSpeed;
    private float currentSpeed;
    [SerializeField] private float speedSmoothVelocity;
    [SerializeField] private float speedSmoothTime;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpSpeed;

    private Transform mainCamTransform;
    CharacterController controller;
    private void Awake()
    {
        mov = this;
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if(Input_Listener.inp.AButton == true)
        {
            StartCoroutine(Jump());
        }
        Input_Listener.inp.ResetAllinputs();
    }

    private void MovePlayer()
    {
        Vector3 movementInput = Input_Listener.inp.LeftJoystickInput;

        Vector3 forward = mainCamTransform.forward;
        Vector3 right = mainCamTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity;
        }

        if (desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
        }

        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
    }

    private IEnumerator Jump()
    {
        //if (controller.isGrounded)
        {
            for(float i = 0;i < 0.5f; i += Time.deltaTime)
            {
                Vector3 jumpDir = new Vector3(0, jumpSpeed - (i * jumpSpeed), 0);
                controller.Move(jumpDir * Time.deltaTime);
                yield return null;
            }
        }
    }
}
