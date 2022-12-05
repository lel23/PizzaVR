using UnityEngine.Audio;
using UnityEngine;

// This class was created with help from this Brackeys video:
// https://www.youtube.com/watch?v=6OT43pvUyfY&t=82s

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

    
}
