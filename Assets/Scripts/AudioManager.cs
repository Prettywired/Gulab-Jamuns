using System.Collections;
using System.Collections.Generic;
//using Unity.Android.Types;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public SoundClass[] musicSounds;
    public AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        SoundClass s = Array.Find(musicSounds, x => x.songName == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ChangeVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
