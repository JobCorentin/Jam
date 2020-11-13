using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Listener : MonoBehaviour
{
    public static Input_Listener inp;

    // Valeur de l'input Joystick gauche
    public Vector3 LeftJoystickInput;

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
        LeftJoystickInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
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

    }

    public void ResetAllinputs()
    {
        XButton = false;
        AButton = false;
    }
}
