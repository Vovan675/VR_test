using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public SimpleMove mover;
    public Transform cameraTransform;
    public Transform forwardCameraTransform;
    public float RotSpeed = 15.0f;
    private Vector3 rotation = Vector3.zero;
    private XRButton currentButton = null;
    private void Update()
    {
        var startPoint = forwardCameraTransform.position;
        if (Physics.Raycast(startPoint, forwardCameraTransform.forward, out var hit, 100, LayerMask.GetMask("Default")))
        {
            var button = hit.collider.GetComponent<XRButton>();
            if (button)
            {
                currentButton?.SetSelected(false);
                currentButton = button;
                currentButton?.SetSelected(true);
            }
            else
            {
                currentButton?.SetSelected(false);
                currentButton = null;
            }
        }
        else
        {
            currentButton?.SetSelected(false);
            currentButton = null;
        }
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentButton?.Press();
        }
    }

    void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        mover.Move(input);

        rotation.x -= Input.GetAxis("Mouse Y") * RotSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -70, 70);
        rotation.y += Input.GetAxis("Mouse X") * RotSpeed;
        cameraTransform.rotation = Quaternion.Euler(rotation);
    }
}
