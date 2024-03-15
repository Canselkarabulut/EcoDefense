using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject soundCloseImage;
    public GameObject musicCloseImage;
    private int soundNum = 1; //1 açık , 0 kapalı
    private int musicNum = 1; //1 açık , 0 kapalı
    public LanguageState languageState;
    private void Start()
    {
        //sesler açık
        soundNum = PlayerPrefs.GetInt("soundNum", 1);
        musicNum = PlayerPrefs.GetInt("musicNum", 1);
        if (soundNum == 1)
        {
            soundCloseImage.SetActive(false);
        }

        if (soundNum == 0)
        {
            soundCloseImage.SetActive(true);
        }

        if (musicNum == 1)
        {
            musicCloseImage.SetActive(false);
        }
        if (musicNum == 0)
        {
            musicCloseImage.SetActive(true);
        }
    }

    public void SoundButton()
    {
        if (soundNum == 1) 
        {
            soundCloseImage.SetActive(true);
            Debug.Log("sesler kapandı");
            soundNum = 0;
            PlayerPrefs.SetInt("soundNum",soundNum);
            return;
        }

        if (soundNum == 0)
        {
            soundCloseImage.SetActive(false);
            Debug.Log("sesler açıldı");
            soundNum = 1;
            PlayerPrefs.SetInt("soundNum",soundNum);
            return;
        }
    }

    public void MusicButton()
    {
        if (musicNum == 1) 
        {
            musicCloseImage.SetActive(true);
            Debug.Log("müzik kapandı");
            musicNum = 0;
            PlayerPrefs.SetInt("musicNum",musicNum);
            return;
        }

        if (musicNum == 0)
        {
            musicCloseImage.SetActive(false);
            Debug.Log("müzik açıldı");
            musicNum = 1;
            PlayerPrefs.SetInt("musicNum",musicNum);
            return;
        }
    }

    public void ClosePanelButton()
    {
        settingPanel.SetActive(false);
    }

    public void SettingPanelOpenButton()
    {
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