using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager musicManager;
    private AudioSource audioSource;
    private float volume=1;
    private bool first = true;

    private void Start()
    {
        musicManager = GetComponent<MusicManager>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.Log("Нет компонента источника звука!");
        }

    }

    public void changeVolume(float volume)
    {
        this.volume = volume;
        audioSource.volume = volume;
    }
    
    public void playSong(string song)
    {
        if (!first)
        {
            StartCoroutine(playSongSlide(song));
        }
        else
        {
            AudioClip audioClip = Resources.Load<AudioClip>("Music/" + song);
            audioSource.clip = audioClip;
            audioSource.Play();
            first = false;
        }
    }
    
    

    IEnumerator playSongSlide(string song)
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Music/" + song);
        while (audioSource.volume>0.01)
        {
            audioSource.volume = audioSource.volume - volume* Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }    
        audioSource.clip = audioClip;
        audioSource.Play();
        while (audioSource.volume<volume)
        {
            audioSource.volume = audioSource.volume + volume * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
