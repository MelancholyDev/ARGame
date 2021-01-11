using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]private Button[] buttons;
    [SerializeField] private string[] animations;
    [SerializeField]private Button settingsButton;
    [SerializeField] private GameObject settings;
    [SerializeField]private Slider soundSlider;
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
            buttons[i].onClick.AddListener(()=>setAnimationAndMusic(animations[j]));
        }
        settingsButton.onClick.AddListener(()=>changeSettingsActive());
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
        if (!currentAnimation.Equals(animation) && !MusicManager.musicManager.changing)
        {
            characterAnimator.SetTrigger(animation);
            MusicManager.musicManager.playSong(animation);
            currentAnimation = animation;
        }
    }
}
