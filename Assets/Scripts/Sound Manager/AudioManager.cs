using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public SoundSource[] soundsMusik; 
    public SoundSource[] soundsEfek;
    public AudioSource SourceMusik;
    public AudioSource SourceEfek;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBG("Backsound Main Screen");
    }

    /*private void Update()
    {
        Mulai_BGM_GuildScreen();
        Mulai_BGM_Credit();
        Mulai_BGM_Main_dari_Credit();
    }*/


    public void PlayBG(string namaAudio)
    {
        SoundSource audioManager = Array.Find(soundsMusik, x => x.namaAudio == namaAudio);

        if (audioManager == null)
        {
            Debug.Log("No Sound Founded: " + namaAudio);
        }
        else
        {
            SourceMusik.clip = audioManager.clip;
            SourceMusik.Play();
        }
    }

    public void StopBG(string namaAudio)
    {
        SoundSource audioManager = Array.Find(soundsMusik, x => x.namaAudio == namaAudio);

        if (audioManager == null)
        {
            Debug.Log("No Sound Founded: " + namaAudio);
        }
        else
        {
            SourceMusik.clip = audioManager.clip;
            SourceMusik.Stop();
        }
    }

    public void PlayEfek(string namaAudio)
    {
        SoundSource audioManager = Array.Find(soundsEfek, x => x.namaAudio == namaAudio);

        if (audioManager == null)
        {
            Debug.Log("No Sound Founded: " + namaAudio);
        }
        else
        {
            SourceEfek.PlayOneShot(audioManager.clip);
        }
    }

    public void MusikSlider(float volume) 
    {
        SourceMusik.volume = volume;
    }

    public void EfekSlider(float volume)
    {
        SourceEfek.volume = volume;
    }

    public void Mulai_BGM_GuildScreen()
    {
        StopBG("Backsound Main Screen");
        PlayBG("Backsound Guild Screen");
    }

    public void Mulai_BGM_Credit()
    {
        StopBG("Backsound Main Screen");
        PlayBG("Backsound Credit Screen");
    }

    public void Mulai_BGM_Main_dari_Credit()
    {
        StopBG("Backsound Credit Screen");
        PlayBG("Backsound Main Screen");
    }

}
