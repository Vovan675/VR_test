using System;
using UnityEngine;
using WebXR;

public class Laser : MonoBehaviour
{
    private XRButton currentButton = null;
    private LineRenderer line;
    public WebXRController hand;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        if (hand.GetButton(WebXRController.ButtonTypes.ButtonA))
        {
            var startPoint = transform.position;
            var endPoint = transform.position + transform.forward * 100;
            if (Physics.Raycast(startPoint, transform.forward, out var hit))
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

                endPoint = hit.point;
            }
            else
            {
                currentButton?.SetSelected(false);
                currentButton = null;
            }
            line.SetPosition(0, startPoint);
            line.SetPosition(1, endPoint);
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }

        if (hand.GetButtonUp(WebXRController.ButtonTypes.ButtonA))
        {
            currentButton?.Press();
        }
    }
}
