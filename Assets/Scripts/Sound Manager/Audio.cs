using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    public SoundSource[] soundsMusik;
    public SoundSource[] soundsEfek;
    public AudioSource SourceMusik;
    public AudioSource SourceEfek;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBG("Bagroud Musik");
    }

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

}

