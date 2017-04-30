﻿using System.Collections;
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


//using UnityEngine;
//using System.Collections;
 
public class AudioManager : MonoBehaviour
{
    public AudioSource Play(AudioClip clip, Transform emitter)
    {
        return Play(clip, emitter, 1f, 1f);
    }

    public AudioSource Play(AudioClip clip, Transform emitter, float volume)
    {
        return Play(clip, emitter, volume, 1f);
    }

    /// <summary>
        /// Plays a sound by creating an empty game object with an AudioSource
        /// and attaching it to the given transform (so it moves with the transform). Destroys it after it finished playing.
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="emitter"></param>
        /// <param name="volume"></param>
        /// <param name="pitch"></param>
        /// <returns></returns>
    public AudioSource Play(AudioClip clip, Transform emitter, float volume, float pitch)
    {
        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clip.name);
        go.transform.position = emitter.position;
        go.transform.parent = emitter;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
        return source;
    }

    public AudioSource Play(AudioClip clip, Vector3 point)
    {
        return Play(clip, point, 1f, 1f);
    }

    public AudioSource Play(AudioClip clip, Vector3 point, float volume)
    {
        return Play(clip, point, volume, 1f);
    }

    /// <summary>
        /// Plays a sound at the given point in space by creating an empty game object with an AudioSource
        /// in that place and destroys it after it finished playing.
        /// </summary>
        /// <param name="clip"></param>
        /// <param name="point"></param>
        /// <param name="volume"></param>
        /// <param name="pitch"></param>
        /// <returns></returns>
    public AudioSource Play(AudioClip clip, Vector3 point, float volume, float pitch)
    {
        //Create an empty game object
        GameObject go = new GameObject("Audio: " + clip.name);
        go.transform.position = point;

        //Create the source
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
        Destroy(go, clip.length);
        return source;
    }
}