using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private Button[] buttons;
    [SerializeField] private string[] animations;
    private Button settingsButton;
    [SerializeField] private GameObject settings;
     private Slider soundSlider;
    private Animator characterAnimator;
    private string currentAnimation="idle";
    void Start()
    {
        settings.SetActive(false);
        GameObject gm = GameObject.FindWithTag("Character");
        if (gm!=null)
        {
            characterAnimator = gm.GetComponent<Animator>();
        }
        else
        {
            Debug.Log("Персонаж не найден!");
            return;
        }
        
        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log(i);
            int j = i;
            buttons[i].clicked+=()=>setAnimationAndMusic(animations[j]);
        }
        settingsButton.clicked+=()=>changeSettingsActive();
    }

    public void callVolumeChange()
    { 
        MusicManager.musicManager.changeVolume(soundSlider.value);
    }
    private void changeSettingsActive()
    {
        settings.SetActive(!settings.activeSelf);
    }
    
    private void setAnimationAndMusic(string animation)
    {
        if (!currentAnimation.Equals(animation))
        {
            characterAnimator.SetTrigger(animation);
            MusicManager.musicManager.playSong(animation);
            currentAnimation = animation;
        }
    }
}
