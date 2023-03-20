using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 movementInput;
    public Transform cameraTransform;
    public CapsuleCollider collider;
    public GameObject watch;

    IEnumerator Start()
    {

        while (true)
        {
            if (Player.instance.rightHand != null)
            {
                Debug.Log("EQUIP");
                Player.instance.rightHand.AttachObject(watch, GrabTypes.Grip, Hand.AttachmentFlags.ParentToHand);
                break;
            }

            yield return null;
        }
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        Vector3 movementDir = Player.instance.hmdTransform.TransformDirection(new Vector3(movementInput.axis.x, 0, movementInput.axis.y));
        transform.position += Vector3.ProjectOnPlane(movementDir, Vector3.up) * Time.deltaTime * 2.0f;

        float headHeight = cameraTransform.localPosition.y;
        collider.height = Mathf.Max(collider.radius, headHeight);
        collider.center = cameraTransform.localPosition - 0.5f * headHeight * Vector3.up;
    }
}
