using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Transform player;
    public Transform cameraTransform;
    public float speed = 4.0f;

    /// <summary>
    /// Move player
    /// </summary>
    /// <param name="input"></param>
    public void Move(Vector2 input)
    {
        var movement = cameraTransform.TransformDirection(new Vector3(input.x, 0, input.y));
        movement = Vector3.ProjectOnPlane(movement, Vector3.up) * (Time.deltaTime * speed);
        player.transform.position += movement;
    }
}
