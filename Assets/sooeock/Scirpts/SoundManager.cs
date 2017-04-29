using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    //AudioSource = > 오디오재생기
    //AudioClip = > 음원.

    public AudioSource musicAudioSource;
    public AudioSource sfxAudioSources;

    SoundLibrary library;

    void Awake()
    {
        library = GetComponent<SoundLibrary>();

    }

    void Start()
    {
        //배경음 임시재생
        PlayMusic("Music_1");

    }
    public void PlayMusic(string _soundName)
    {
        musicAudioSource.clip = library.GetClipFromName(_soundName);
        musicAudioSource.Play();
    }

    public void PlaySFX(string _soundName)
    {
        sfxAudioSources.PlayOneShot(library.GetClipFromName(_soundName));

    }
}
