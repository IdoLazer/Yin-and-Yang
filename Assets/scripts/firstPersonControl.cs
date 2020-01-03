using System.Collections;
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
        cameraT = Camera.main.transform;
    }

    void Update()
    {
        if (tag == "Player2")
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSenX);
            // if we want the camera to move
            //verLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSenY;
            //verLookRotation = Mathf.Clamp(verLookRotation, -30, 30);
            //cameraT.localEulerAngles = Vector3.left * verLookRotation;

            Vector3 moveDir = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVel, .15f);

        }
        if (tag == "Player1")
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * mouseSenX);
            // if we want the camera to move
            //verLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSenY;
            //verLookRotation = Mathf.Clamp(verLookRotation, -30, 30);
            //cameraT.localEulerAngles = Vector3.left * verLookRotation;

            Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVel, .15f);

        }


    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveAmount)*Time.fixedDeltaTime);
    }
}
