﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{
    private GameObject obj_Audio = null;
    private AudioSource bgm_source = null;
    private List<AudioSource> sound_source = new List<AudioSource>();
    const int Fade = 5000;
    public float BGM_Volume{
        get
        { 
            return bgm_source.volume; 
        } 
        set
        {
            bgm_source.volume = BGM_Volume;
        }
    }
    public void PlayBGM(string name)
    {
        if (bgm_source == null)
        {
            obj_Audio = new GameObject();
            obj_Audio.name = "Audio";
        }
        if (bgm_source == null)
            bgm_source = obj_Audio.AddComponent<AudioSource>();
        Debug.Log("[消息]播放BGM:" + name);
        bgm_source.clip = Resources.Load<AudioClip>("Audio/BGM/" + name);
        bgm_source.volume = 0.05f;
        bgm_source.Play();
    }
    public void PlayBGM()
    {

    }
    public void SwitchBGM()
    {
        if (bgm_source.isPlaying)
            bgm_source.Pause();
        else
            bgm_source.UnPause();
    }
    public void StopBGM()
    {
        bgm_source.Pause();
    }
    
    public void PlaySound(string name)
    {
        if (bgm_source == null)
        {
            obj_Audio = new GameObject();
            obj_Audio.name = "Audio";
            bgm_source = obj_Audio.AddComponent<AudioSource>();
        }
        AudioSource audioSource = obj_Audio.AddComponent<AudioSource>();
        sound_source.Add(audioSource);
        audioSource.clip = Resources.Load<AudioClip>("Audio/Sounds/" + name);
        audioSource.Play();
        for(int i=0;i<sound_source.Count;i++)
        {
            if(!sound_source[i].isPlaying)
            {
                GameObject.Destroy(sound_source[i]);
                sound_source.RemoveAt(i);
            }
        }
    }
    public void PlaySound(string name,float volume)
    {
        if (bgm_source == null)
        {
            obj_Audio = new GameObject();
            obj_Audio.name = "Audio";
            bgm_source = obj_Audio.AddComponent<AudioSource>();
        }
        AudioSource audioSource = obj_Audio.AddComponent<AudioSource>();
        sound_source.Add(audioSource);
        audioSource.clip = Resources.Load<AudioClip>("Audio/Sounds/" + name);
        audioSource.volume = volume;
        audioSource.Play();
    }
    void CleanAudioSource()
    {
        for (int i = 0; i < sound_source.Count; i++)
        {
            if (!sound_source[i].isPlaying)
            {
                GameObject.Destroy(sound_source[i]);
                sound_source.RemoveAt(i);
            }
        }
    }
    public AudioManager()
    {
        TheGame.Getinstance().GameMain.MonoManager.AddUpdateListener(CleanAudioSource);
    }
}
