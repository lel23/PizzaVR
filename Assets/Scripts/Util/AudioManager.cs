using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
// This class was created with help from this Brackeys video:
// https://www.youtube.com/watch?v=6OT43pvUyfY&t=82s


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private string currentScene;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public Sound Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        return s;
    }

    public Sound getSound(string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }
}
