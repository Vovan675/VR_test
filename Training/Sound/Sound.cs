using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioSource source;
    public AudioClip clip;
    public float volume = 1.0f;
    public bool playOnAwake = false;
}
