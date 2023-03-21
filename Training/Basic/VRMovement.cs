using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class VRMovement : MonoBehaviour
{
    public WebXRController hand;
    public SimpleMove move;

    void Update()
    {
        Vector2 input = hand.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        move.Move(input);
    }
}
