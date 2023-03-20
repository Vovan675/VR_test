using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;
    public float Volume;
    public bool PlayOnAwake = false;
    public AudioSource Source;
}
