﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPersonControl : MonoBehaviour
{
    public float mouseSenX = 250f;
    public float mouseSenY = 250f;
    public float walkSpeed;
    Transform cameraT;
    float verLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVel;

    void Start()
    {
    }

    void Update()
    {
        if (tag == "Player1")
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Player2Y"));
            // if we want the camera to move
            //verLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSenY;
            //verLookRotation = Mathf.Clamp(verLookRotation, -30, 30);
            //cameraT.localEulerAngles = Vector3.left * verLookRotation;
            if (Input.GetAxis("Player2X") <= Mathf.Abs(1)) 
            { 
                Vector3 moveDir = new Vector3(0, 0, -Input.GetAxis("Player2X")).normalized;
                Vector3 targetMoveAmount = moveDir * walkSpeed;
                moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVel, .15f);
            }

        }
        if (tag == "Player2")
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal"));
            // if we want the camera to move
            //verLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSenY;
            //verLookRotation = Mathf.Clamp(verLookRotation, -30, 30);
            //cameraT.localEulerAngles = Vector3.left * verLookRotation;
            if (Input.GetAxis("Vertical") <= Mathf.Abs(1))
            {
                Vector3 moveDir = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
                Vector3 targetMoveAmount = moveDir * walkSpeed;
                moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVel, .15f);
            }

        }


    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount)*Time.fixedDeltaTime);
    }
}