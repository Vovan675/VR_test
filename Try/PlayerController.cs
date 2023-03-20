using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// VR Input for movement axis
    /// </summary>
    public SteamVR_Action_Vector2 movementInput;

    /// <summary>
    /// Speed of movement
    /// </summary>
    public float movementSpeed = 4.0f;

    private CapsuleCollider collider;
    private Transform hmdTransform;

    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        hmdTransform = Player.instance.hmdTransform;
    }

    void Update()
    {
        // Movement
        Vector3 movement = hmdTransform.TransformDirection(movementInput.axis);
        transform.position += movement * (movementSpeed * Time.deltaTime);

        // Collider size
        float height = hmdTransform.localPosition.y;
        collider.height = height;
        collider.center = hmdTransform.localPosition - Vector3.up * (0.5f * height);
    }
}
