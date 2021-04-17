using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Object = System.Object;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;
    public Sounds[] Themes;
    
    public AudioMixerGroup Master;
    public AudioMixerGroup SFX;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        foreach (var s in sound)
        {
            s.source =gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = SFX;
        }
        foreach (var s in Themes)
        {
            s.source =gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = Master;
        }
    }

    void Start()
    {
        Playthemes("Main_Theme");
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
    public void Playthemes(string name)
    {
        foreach (var s2 in Themes)
        {
            s2.source.Stop();
        }
        Sounds s = Array.Find(Themes, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if (PauseMenu.GameIsPaused)
        {
            s.source.pitch *= .5f;
        }
        s.source.Play();
    }
    
}
