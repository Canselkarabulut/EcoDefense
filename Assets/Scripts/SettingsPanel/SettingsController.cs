using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject soundCloseImage;
    public GameObject musicCloseImage;
    private int soundNum = 1; //1 açık , 0 kapalı
    private int musicNum = 1; //1 açık , 0 kapalı
    public LanguageState languageState;


    public Button settingButton;
    public Button playButton;
    
    
  //  public static bool isSoundNum; // true ses açık, false kapalı
  //  public static bool isMusicNum; // true ses açık, false kapalı

    private void Start()
    {
        //sesler açık
        soundNum = PlayerPrefs.GetInt("soundNum", 1);
        musicNum = PlayerPrefs.GetInt("musicNum", 1);
        
        if (soundNum == 1)
        {
        //    isSoundNum = true; // ses açık
            soundCloseImage.SetActive(false);
        }

        if (soundNum == 0)
        {
       //     isSoundNum = false; // ses kapalı
            soundCloseImage.SetActive(true);
        }

        if (musicNum == 1)
        {
          //  isMusicNum = true;
            musicCloseImage.SetActive(false);
        }

        if (musicNum == 0)
        {
          //  isMusicNum = false;
            musicCloseImage.SetActive(true);
        }
    }

    public void SoundButton()
    {
        if (soundNum == 1)
        {
            soundCloseImage.SetActive(true);
          //  isSoundNum = false; // açık ses kapandı
            Debug.Log("sesler kapandı");
            soundNum = 0;
            PlayerPrefs.SetInt("soundNum", soundNum);
            return;
        }

        if (soundNum == 0)
        {
            soundCloseImage.SetActive(false);
           // isSoundNum = true; // kapalı ses açıldı
            Debug.Log("sesler açıldı");
            soundNum = 1;
            PlayerPrefs.SetInt("soundNum", soundNum);
            return;
        }
    }

    public void MusicButton()
    {
        if (musicNum == 1)
        {
            musicCloseImage.SetActive(true);
          //  isMusicNum = false; // açık müzik kapandı
            Debug.Log("müzik kapandı");
            musicNum = 0;
            PlayerPrefs.SetInt("musicNum", musicNum);
            return;
        }

        if (musicNum == 0)
        {
            musicCloseImage.SetActive(false);
         //   isMusicNum = true; // kapalı müzik açıldı
            Debug.Log("müzik açıldı");
            musicNum = 1;
            PlayerPrefs.SetInt("musicNum", musicNum);
            return;
        }
    }

    public void ClosePanelButton()
    {
        if (settingButton != null && playButton != null)
        {
            settingButton.interactable = true;
            playButton.interactable = true;
        }
        settingPanel.SetActive(false);
    }

    public void SettingPanelOpenButton()
    {
        if (settingButton != null && playButton != null)
        {
            settingButton.interactable = false;
            playButton.interactable = false;
        }
        settingPanel.SetActive(true);
    }

    //   public void TurkishButton()
    //   {
    //       languageState = LanguageState.Turkish;
    //   }
//
    //   public void EnglishButton()
    //   {
    //       languageState = LanguageState.English;
    //   }
}