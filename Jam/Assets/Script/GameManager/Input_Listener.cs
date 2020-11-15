using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Listener : MonoBehaviour
{
    public static Input_Listener inp;

    //Keyboard  and mouse Input
    //Valeur de l'input clic droit
    public bool rightClick;

    //Valeur de l'input clic gauche
    public bool leftClick;


    //Controlleur Input
    // Valeur de l'input Joystick gauche
    public Vector3 DirectionInput;

    //Valeur de l'input Joystick droit
    public Vector3 RightJoystickInput;

    //Valeur de l'input Bouton A
    public bool AButton;

    //Valeur de l'input Bouton X
    public bool XButton;

    //Valeur de l'input LeftTrigger
    public float LeftTriggerAxis;

    //Valeur de l'input RightTrigger
    public float RightTriggerAxis;

    void Awake()
    {
        inp = this;
    }

    // Update is called once per frame
    void Update()
    {
        DirectionInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        RightJoystickInput = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")).normalized;

        LeftTriggerAxis = Input.GetAxis("LeftTrigger");
        RightTriggerAxis = Input.GetAxis("RightTrigger");

        if (Input.GetButtonDown("XButton"))
        {
            XButton = true;
            Debug.Log("X button");
        }

        if (Input.GetButtonDown("AButton"))
        {
            AButton = true;
            Debug.Log("A button");
        }

        if (Input.GetMouseButtonDown(0))
        {
            rightClick = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rightClick = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            leftClick = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            leftClick = false;
        }

    }

    public void ResetAllinputs()
    {
        XButton = false;
        AButton = false;
    }
}
