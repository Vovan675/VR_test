using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class KickableDoor : MonoBehaviour
{
    private int kicks = 0;
    public int maxKicks = 3;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected virtual void OnHandHoverBegin(Hand hand)
    {
        hand.GetEstimatedPeakVelocities(out var velocity, out var angularVelocity);
        if (velocity.magnitude > 1.5f)
        {
            Kick();
        }
    }

    public void Kick()
    {
        kicks++;
        GetComponent<Renderer>().material.color = Random.ColorHSV(0.2f, 1);
        if (kicks >= maxKicks)
        {
            Break();
        }
    }

    private void Break()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(this);
        //Destroy(gameObject);
    }
}
