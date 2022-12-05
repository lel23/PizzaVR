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

        // load the music for the current scene
        loadSceneMusic(currentScene, LoadSceneMode.Additive);
    }

    public Sound Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        return s;
    }

    public Sound getSound (string name)
    {
        return Array.Find(sounds, sound => sound.name == name);
    }

    void loadSceneMusic(string scene, LoadSceneMode mode)
    {
        // load appropriate music for level 1
        if (scene == "Level 1")
        {
            Sound idle = Play("level1_idle");
            Sound piano = getSound("level1_piano");
            piano.source.volume = 0;
            Play("level1_piano");
            Sound drums = getSound("level1_drums");
            drums.source.volume = 0;
            Play("level1_drums");
        }

        // load music for level 2
        else if (scene == "Level 2")
        {
            Sound idle = Play("level2_idle");
            Sound piano = getSound("level2_piano");
            piano.source.volume = 0;
            Play("level2_piano");
            Sound drums = getSound("level2_drums");
            drums.source.volume = 0;
            Play("level2_drums");
            Sound guitar = getSound("level2_guitar");
            guitar.source.volume = 0;
            Play("level2_guitar");
        }

        // load music for level 3
        else if (scene == "Level 3")
        {
            Sound idle = Play("level3_idle");
            Sound piano = getSound("level3_piano");
            piano.source.volume = 0;
            Play("level3_piano");
            Sound drums = getSound("level3_drums");
            drums.source.volume = 0;
            Play("level3_drums");
            Sound guitar = getSound("level3_guitar");
            guitar.source.volume = 0;
            Play("level3_guitar");
            Sound triangle = getSound("level3_triangle");
            triangle.source.volume = 0;
            Play("level3_triangle");
        }
        else if (scene == "Tutorial")
        {
            Sound idle = Play("tutorial_idle");
            Sound piano = getSound("tutorial_piano");
            piano.source.volume = 0;
            Play("tutorial_piano");
            Sound drums = getSound("tutorial_drums");
            drums.source.volume = 0;
            Play("tutorial_drums");
            Sound guitar = getSound("tutorial_guitar");
            guitar.source.volume = 0;
            Play("tutorial_guitar");
            Sound triangle = getSound("tutorial_triangle");
            triangle.source.volume = 0;
            Play("tutorial_triangle");
        }
        else if (scene == "Title Screen")
        {
            Play("title_screen");
        }
        else if (scene == "Win Screen")
        {
            Play("you win");
        }
        else if (scene == "Level Select")
        {
            Play("level_select");
        }
    }

    public void turnUpAllTracks()
    {
        if (currentScene == "Level 1")
        {
            Sound drums = getSound("level1_drums");
            drums.source.volume = 1;

            Sound piano = getSound("level1_piano");
            piano.source.volume = 1;
        }
        else if (currentScene == "Level 2")
        {
            Sound drums = getSound("level2_drums");
            drums.source.volume = 1;

            Sound guitar = getSound("level2_guitar");
            guitar.source.volume = 1;

            Sound piano = getSound("level2_piano");
            piano.source.volume = 1;
        }
        else if (currentScene == "Level 3")
        {
            Sound drums = getSound("level3_drums");
            drums.source.volume = 1;

            Sound guitar = getSound("level3_guitar");
            guitar.source.volume = 1;

            Sound triangle = getSound("level3_triangle");
            triangle.source.volume = 1;

            Sound piano = getSound("level3_piano");
            piano.source.volume = 1;
        }
        else if (currentScene == "Tutorial")
        {
            Sound drums = getSound("tutorial_drums");
            drums.source.volume = 1;

            Sound guitar = getSound("tutorial_guitar");
            guitar.source.volume = 1;

            Sound triangle = getSound("tutorial_triangle");
            triangle.source.volume = 1;

            Sound piano = getSound("tutorial_piano");
            piano.source.volume = 1;
        }
    }

    public void turnOnPianoSoundtrack()
    {
        if (currentScene == "Level 1")
        {
            Sound drums = getSound("level1_drums");
            drums.source.volume = 0;

            Sound piano = getSound("level1_piano");
            piano.source.volume = 1;
        }
        else if (currentScene == "Level 2")
        {
            Sound drums = getSound("level2_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("level2_guitar");
            guitar.source.volume = 0;

            Sound piano = getSound("level2_piano");
            piano.source.volume = 1;
        }
        else if (currentScene == "Level 3")
        {
            Sound drums = getSound("level3_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("level3_guitar");
            guitar.source.volume = 0;

            Sound triangle = getSound("level3_triangle");
            triangle.source.volume = 0;

            Sound piano = getSound("level3_piano");
            piano.source.volume = 1;
        }
        else if (currentScene == "Tutorial")
        {
            Sound drums = getSound("tutorial_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("tutorial_guitar");
            guitar.source.volume = 0;

            Sound triangle = getSound("tutorial_triangle");
            triangle.source.volume = 0;

            Sound piano = getSound("tutorial_piano");
            piano.source.volume = 1;
        }
    }

    public void turnOnDrumsSoundtrack()
    {
        if (currentScene == "Level 1")
        {
            Sound drums = getSound("level1_drums");
            drums.source.volume = 1;

            Sound piano = getSound("level1_piano");
            piano.source.volume = 0;
        }
        else if (currentScene == "Level 2")
        {
            Sound drums = getSound("level2_drums");
            drums.source.volume = 1;

            Sound guitar = getSound("level2_guitar");
            guitar.source.volume = 0;

            Sound piano = getSound("level2_piano");
            piano.source.volume = 0;
        }
        else if (currentScene == "Level 3")
        {
            Sound drums = getSound("level3_drums");
            drums.source.volume = 1;

            Sound guitar = getSound("level3_guitar");
            guitar.source.volume = 0;

            Sound triangle = getSound("level3_triangle");
            triangle.source.volume = 0;

            Sound piano = getSound("level3_piano");
            piano.source.volume = 0;
        }
        else if (currentScene == "Tutorial")
        {
            Sound drums = getSound("tutorial_drums");
            drums.source.volume = 1;

            Sound guitar = getSound("tutorial_guitar");
            guitar.source.volume = 0;

            Sound triangle = getSound("tutorial_triangle");
            triangle.source.volume = 0;

            Sound piano = getSound("tutorial_piano");
            piano.source.volume = 0;
        }
    }

    public void turnOnGuitarSoundtrack()
    {
        if (currentScene == "Level 2")
        {
            Sound drums = getSound("level2_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("level2_guitar");
            guitar.source.volume = 1;

            Sound piano = getSound("level2_piano");
            piano.source.volume = 0;
        }
        else if (currentScene == "Level 3")
        {
            Sound drums = getSound("level3_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("level3_guitar");
            guitar.source.volume = 1;

            Sound triangle = getSound("level3_triangle");
            triangle.source.volume = 0;

            Sound piano = getSound("level3_piano");
            piano.source.volume = 0;
        }
        else if (currentScene == "Tutorial")
        {
            Sound drums = getSound("tutorial_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("tutorial_guitar");
            guitar.source.volume = 1;

            Sound triangle = getSound("tutorial_triangle");
            triangle.source.volume = 0;

            Sound piano = getSound("tutorial_piano");
            piano.source.volume = 0;
        }
    }

    public void turnOnTriangleSoundtrack()
    {
        if (currentScene == "Level 3")
        {
            Sound drums = getSound("level3_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("level3_guitar");
            guitar.source.volume = 0;

            Sound triangle = getSound("level3_triangle");
            triangle.source.volume = 1;

            Sound piano = getSound("level3_piano");
            piano.source.volume = 0;
        }
        else if (currentScene == "Tutorial")
        {
            Sound drums = getSound("tutorial_drums");
            drums.source.volume = 0;

            Sound guitar = getSound("tutorial_guitar");
            guitar.source.volume = 0;

            Sound triangle = getSound("tutorial_triangle");
            triangle.source.volume = 1;

            Sound piano = getSound("tutorial_piano");
            piano.source.volume = 0;
        }
    }

    public void conductorDeathNoise()
    {
        if (currentScene == "Level 1") Play("conductor_death_level1");
        else if (currentScene == "Level 2") Play("conductor_death_level2");
        else if (currentScene == "Level 3") Play("conductor_death_level3");
        else if (currentScene == "Tutorial") Play("conductor_death_tutorial");
    }
}
