using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 5;
    public Transform forceFromPos;
    public Transform forceToPos;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    [ContextMenu("Apply force")]
    public void Apply()
    {
        rb.AddForceAtPosition((forceToPos.position - forceFromPos.position).normalized * force, forceFromPos.position, ForceMode.Acceleration);
    }
}
