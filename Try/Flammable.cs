using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flammable : MonoBehaviour
{
    public ParticleSystem particle;
    public bool isFired = false;
    public UnityEvent onFired;

    void Update()
    {
        
    }

    /// <summary>
    /// Set fire
    /// </summary>
    public void Fire()
    {
        if (!isFired)
        {
            isFired = true;
            particle.Play();
            onFired?.Invoke();
        }
    }
}
