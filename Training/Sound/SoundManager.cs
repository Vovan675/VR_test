using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// All sounds
    /// </summary>
    public List<Sound> sounds = new List<Sound>();

    /// <summary>
    /// Singleton instance
    /// </summary>
    public static SoundManager instance;
    void Start()
    {
        // Destroy if instance
        if (instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
        // Set singleton instance
        instance = this;

        // Init sounds
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            if (sound.playOnAwake)
            {
                sound.source.loop = true;
                sound.source.Play();
            }
        }
    }

    /// <summary>
    /// Play sound by name
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        var sound = sounds.Find(x => x.name == name);
        if (sound == null)
        {
            Debug.LogError("Sound not found");
        }
        else
        {
            sound.source.Play();
        }
    }
}
