using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour
{
    /// <summary>
    /// Fire spread speed
    /// </summary>
    public float spreadSpeed = 0.5f;
    void Update()
    {
        var colliders = Physics.OverlapSphere(transform.position, transform.localScale.x);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Fire"))
            {
                var flammable = collider.GetComponent<Flammable>();
                if (flammable && !flammable.isFired)
                {
                    flammable.Fire();
                }
            }
        }
        transform.localScale += Vector3.one * (spreadSpeed * Time.deltaTime);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
    }
#endif
}
