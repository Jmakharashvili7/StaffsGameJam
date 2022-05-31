using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{



    private Dictionary<string, float> _soundTimerDic;

    public SoundClass[] _soundClasses;

    private int _enemycount;


    #region Awake/Start/Update
    public void Awake()
    {

        

        _soundTimerDic = new Dictionary<string, float>();

        foreach (SoundClass sound in _soundClasses)
        {
            sound._audioSource = gameObject.AddComponent<AudioSource>();
            sound._audioSource.clip = sound._audioClip;
            sound._audioSource.outputAudioMixerGroup = sound._audioMixer;
            sound._audioSource.volume = sound._volume;
            sound._audioSource.loop = sound._loop;

            if (sound._cooldown)
            {
                _soundTimerDic[sound._name] = 0f;
            }
        }


    }

    private void Start()
    {
        Play("Soundtrack");
        _enemycount = 5;
    }
    #endregion

    #region AudioControls
    public void Play(string name)
    {

        SoundClass sound = Array.Find(_soundClasses, soundClass => soundClass._name == name);

        if (sound == null)
        {
            Debug.LogError("Sound named -> " + name + "doesn't exist");
            return;
        }

        if (!CanPlay(sound))
        {
            return;
        }



        sound._audioSource.Play();

    }

    public void Stop(string name)
    {
        SoundClass sound = Array.Find(_soundClasses, soundClass => soundClass._name == name);


        if (sound == null)
        {
            Debug.LogError("Sound named -> " + name + "doesn't exist");
            return;
        }

        sound._audioSource.Stop();


    }

    public void Pause(string name)
    {
        SoundClass sound = Array.Find(_soundClasses, soundClass => soundClass._name == name);

        if (sound == null)
        {
            Debug.LogError("Sound named -> " + name + "doesn't exist");
            return;
        }

        sound._audioSource.Pause();

    }

    public void Resume(string name)
    {
        SoundClass sound = Array.Find(_soundClasses, soundClass => soundClass._name == name);

        if (sound == null)
        {
            Debug.LogError("Sound named -> " + name + "doesn't exist");
            return;
        }

        sound._audioSource.UnPause();
    }

    public bool CanPlay(SoundClass _sounds)
    {


        if (_soundTimerDic.ContainsKey(_sounds._name))
        {

            float _lastPlayed = _soundTimerDic[_sounds._name];

            if (_lastPlayed + _sounds._audioClip.length < Time.time)
            {
                _soundTimerDic[_sounds._name] = Time.time;
                return true;
            }
            return false;
        }
        return true;
    }
    #endregion

    #region SoundtrackControls
    public void PlaySoundTrack()
    {


        if (_enemycount < 6)
        {
            Play("Soundtrack3");

        }
        else if (_enemycount >= 6 && _enemycount < 9)
        {
            Play("Soundtrack2");
            Stop("Soundtrack");

        }
        else if (_enemycount >= 9)
        {
            Play("Soundtrack");
            Stop("Soundtrack2");

        }
    }

    public void ResumeSoundTrack()
    {


        if (_enemycount < 6)
        {

            Resume("Soundtrack3");
        }
        else if (_enemycount >= 6 && _enemycount < 9)
        {

            Resume("Soundtrack2");
        }
        else if (_enemycount >= 9)
        {
            Resume("Soundtrack");

        }

    }

    public void StopSoundTrack()
    {


        if (_enemycount < 6)
        {

            Pause("Soundtrack3");
        }
        else if (_enemycount >= 6 && _enemycount < 9)
        {
            Pause("Soundtrack2");
        }
        else if (_enemycount >= 9)
        {
            Pause("Soundtrack");
        }
    }

   

    //Working on this later on so I can manage to get a adaptive soundtrack
    //public IEnumerator CheckSoundtrack(float _waitTime)
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(_waitTime);
    //        PlaySoundTrack();
    //    }

    //}

    #endregion




}