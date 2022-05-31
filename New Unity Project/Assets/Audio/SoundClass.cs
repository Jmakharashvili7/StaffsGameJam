using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundClass
{
    [HideInInspector]
    public AudioSource _audioSource;
    public AudioClip _audioClip;
    public AudioMixerGroup _audioMixer;


    public string _name;

    public bool _cooldown;
    public bool _loop;


    [Range(0f, 1f)]
    public float _volume;


}