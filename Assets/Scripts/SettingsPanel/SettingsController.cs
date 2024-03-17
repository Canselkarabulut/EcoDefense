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
    private int soundNum; //1 açık , 0 kapalı
    private int musicNum; //1 açık , 0 kapalı
    public LanguageState languageState;


    public Button settingButton;
    public Button playButton;

    [Header("Audio")] public AudioSource camAudio;
    public AudioSource playerAudio;
    public AudioSource fireAudio;


    public EnemySpawn enemySpawn;

    private void Start()
    {
        //sesler açık
        soundNum = PlayerPrefs.GetInt("soundNum");
        musicNum = PlayerPrefs.GetInt("musicNum");
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
            soundNum = 0;
            PlayerPrefs.SetInt("soundNum", soundNum);
            GameAudioState(false, false, false, false, false, false, false);
            return;
        }

        if (soundNum == 0)
        {
            soundCloseImage.SetActive(false);
            // isSoundNum = true; // kapalı ses açıldı
            soundNum = 1;
            PlayerPrefs.SetInt("soundNum", soundNum);
            GameAudioState(true, true, true, true, true, true, true);
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

    public GameObject enemys;
    private EnemyLife enemyLife;

    public void GameAudioState(bool camAudioBool, bool playerAudioBool, bool fireAudioBool, bool enemyBornBool,
        bool enemyCoinBool, bool enemyTriggerBulletBool, bool enemyWalkBool)
    {
        if (camAudio != null && playerAudio != null && fireAudio != null)
        {
            camAudio.enabled = camAudioBool;
            playerAudio.enabled = playerAudioBool;
            fireAudio.enabled = fireAudioBool;
        }

        if (enemys != null)
        {
            if (enemys.transform.childCount > 0)
            {
                for (int i = 0; i < enemys.transform.childCount; i++)
                {
                    enemyLife = enemys.transform.GetChild(i).GetComponent<EnemyLife>();
                    if (enemyLife.enemyBorn != null && enemyLife.enemyCoin != null &&
                        enemyLife.enemyTriggerBullet != null && enemyLife.enemyWalk != null)
                    {
                        enemyLife.enemyBorn.enabled = enemyBornBool;
                        enemyLife.enemyCoin.enabled = enemyCoinBool;
                        enemyLife.enemyTriggerBullet.enabled = enemyTriggerBulletBool;
                        enemyLife.enemyWalk.enabled = enemyWalkBool;
                    }
                }
            }
        }
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