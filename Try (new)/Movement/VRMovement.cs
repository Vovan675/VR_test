using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class VRMovement : MonoBehaviour
{
    public SimpleMove mover;
    public WebXRController hand;
    void FixedUpdate()
    {
        mover.Move(hand.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick));
    }
}
