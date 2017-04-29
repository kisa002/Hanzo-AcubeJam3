using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundLibrary : MonoBehaviour
{
    public SoundList[] soundLists;

    Dictionary<string, AudioClip> groupDictionary = new Dictionary<string, AudioClip>();

    void Awake()
    {
        for (int i = 0; i < soundLists.Length; i++)
        {
            groupDictionary.Add(soundLists[i].soundName, soundLists[i].clip);
        }
    }

    //디셔너리에서 가져온다.
    public AudioClip GetClipFromName(string _name)
    {
        if (groupDictionary.ContainsKey(_name))
        {
            AudioClip sounds = groupDictionary[_name];   
            return sounds;
        }
        return null;
    }

    [System.Serializable]
    public struct SoundList
    {
        public string soundName;
        public AudioClip clip;
    };

}
