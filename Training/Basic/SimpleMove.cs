using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;

    public float speed;

    private void FixedUpdate()
    {
        controller.SimpleMove(Physics.gravity);
    }

    public void Move(Vector2 input)
    {
        if (input.magnitude < 0.1)
            return;

        input.Normalize();

        // Calculate angle, rotation and movement
        float angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, controller.transform.up);
        Vector3 movement = (rotation * cameraTransform.forward).normalized * speed;

        // Apply movement
        controller.SimpleMove(movement);
    }
}
