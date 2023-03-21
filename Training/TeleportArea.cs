using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArea : MonoBehaviour
{
    /// <summary>
    /// End position
    /// </summary>
    public Transform target;

    public Vector3 GetDeltaPos()
    {
        return target.position - transform.position;
    }

    public void ApplyForce()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
    }
}
