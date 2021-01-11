using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private string[] allSongs;
    public static MusicManager musicManager;
    private Dictionary<string,AudioClip> songs=new Dictionary<string, AudioClip>();
    private AudioSource audioSource;
    private float volume=1;
    private bool first = true;
    private float kf = 2;
    public bool changing = false;

    private void Start()
    {
        loadSongs();
        musicManager = GetComponent<MusicManager>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.Log("Нет компонента источника звука!");
        }
        else
        {
            audioSource.loop = true;
        }

    }

    private void loadSongs()
    {
        for (int i = 0; i < allSongs.Length; i++)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("Music/" + allSongs[i]);
            Debug.Log(audioClip==null);
            songs.Add(allSongs[i],audioClip);
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
            
            audioSource.clip = songs[song];
            audioSource.Play();
            first = false;
        }
    }
    
    

    IEnumerator playSongSlide(string song)
    {
        changing = true;
        while (audioSource.volume>0.01)
        {
            audioSource.volume = audioSource.volume - kf*volume* Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        audioSource.clip = songs[song];
        audioSource.Play();
        while (audioSource.volume<volume)
        {
            audioSource.volume = audioSource.volume + kf*volume * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        changing = false;
    }

}
