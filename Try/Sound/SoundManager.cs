using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    /// <summary>
    /// Singleton instance
    /// </summary>
    public static SoundManager Instance => instance;

    [SerializeField] private List<Sound> sounds = new List<Sound>();

    void Start()
    {
        // Init singleton
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;


        // Init sounds
        foreach (var sound in sounds)
        {
            var source = gameObject.AddComponent<AudioSource>();
            sound.Source = source;
            source.clip = sound.Clip;
            source.volume = sound.Volume;
            if (sound.PlayOnAwake)
            {
                source.Play();
            }
        }
    }

    /// <summary>
    /// Play sound by its name
    /// </summary>
    /// <param name="name"></param>
    public void PlaySound(string name)
    {
        var sound = sounds.Find(x => x.Name == name);
        if (sound == default)
        {
            Debug.LogError("Sound not found " + name);
            return;
        }
        sound.Source.Play();
    }
    
}
