using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    // Spread speed
    public float spreadRate = 0.5f;
    // Layer with fireable objects
    public LayerMask spreadLayer;


    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, transform.localScale.x / 2, spreadLayer);

        foreach (var collider in colliders)
        {
            var flammable = collider.GetComponent<Flammable>();
            if (flammable && !flammable.isFire)
            {
                flammable.Fire();
            }
        }

        transform.localScale += Vector3.one * (spreadRate * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x / 2);
    }
}
