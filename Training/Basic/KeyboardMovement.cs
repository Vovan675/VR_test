using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public Camera camera;
    public SimpleMove move;
    public float RotSpeed = 5.0f;

    private Vector3 rotation = Vector3.zero;
    private XRButton currentSelected = null;

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        move.Move(input);

        rotation.x -= Input.GetAxis("Mouse Y") * RotSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -70, 70);
        rotation.y += Input.GetAxis("Mouse X") * RotSpeed;

        camera.transform.rotation = Quaternion.Euler(rotation);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out var hit, 10))
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

        }
        else
        {
            currentSelected?.SetSelected(false);
            currentSelected = null;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentSelected?.Click();
        }
    }
}
