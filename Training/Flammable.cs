using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Flammable : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public UnityEvent onFireEvent;
    public bool isFire = false;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        
    }

    public void Fire()
    {
        if (!isFire)
        {
            isFire = true;
            particleSystem.Play(true);
            onFireEvent.Invoke();
        }
    }
}
