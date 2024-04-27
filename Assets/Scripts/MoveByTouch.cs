using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick joyStick;

    public float runSpeed = 40f;
    float horizontalMovement = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {

        horizontalMovement = joyStick.Horizontal * runSpeed;

        float verticaleMovement = joyStick.Vertical;

        //for (int i = 0; i < Input.touchCount; i++)
        //{
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        //    Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        //}

        if (verticaleMovement >= 0.5f)
        {
            jump = true;
        }


        //if(Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //    touchPosition.z = 0;
        //    transform.position = touchPosition;
        //}
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
