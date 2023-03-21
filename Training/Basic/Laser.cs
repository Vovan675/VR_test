using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;
using WebXR.Interactions;

public class Laser : MonoBehaviour
{
    public WebXRController hand;
    private LineRenderer line;
    private XRButton currentSelected = null;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (hand.GetButton(WebXRController.ButtonTypes.ButtonA))
        {
            UpdateLaser();
        }
        
        if (hand.GetButtonDown(WebXRController.ButtonTypes.ButtonA))
        {
            line.enabled = true;
        }
        
        if (hand.GetButtonUp(WebXRController.ButtonTypes.ButtonA))
        {
            line.enabled = false;
            if (currentSelected)
            {
                currentSelected.Click();
            }
        }
    }

    private void UpdateLaser()
    {
        Vector3 end = transform.position + transform.forward * 5;
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 10))
        {
            XRButton button = hit.transform.GetComponent<XRButton>();
            if (button)
            {
                currentSelected?.SetSelected(false);
                currentSelected = button;
                currentSelected.SetSelected(true);
            }
            else
            {
                currentSelected?.SetSelected(false);
                currentSelected = null;
            }

            end = hit.point;
        }
        else
        {
            currentSelected?.SetSelected(false);
            currentSelected = null;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, end);
    }
}
