using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddMoneyButton : MonoBehaviour
{
    public GameObject adsPanel;
    public GameObject tutorialHealthAds;
    public WaveControl waveControl;
    public GameObject gameplayTutorial;
    [Header("None")] public FloatingJoystick floatingJoystick;
    public GameObject player;
    public Button upgradeButton;
    
    [Header("adsShowControl")]
    public AdsShowControl adsShowControl;
    public void AddPanelClose()
    {
        upgradeButton.interactable = true;
        player.GetComponent<PlayerController>().floatingJoystick = floatingJoystick;
        floatingJoystick.gameObject.SetActive(true);
        adsPanel.SetActive(false);
        adsShowControl.AdsShow();

    }
   
    public void AddHealthPanelClose()
    {
        tutorialHealthAds.SetActive(false);
        adsShowControl.AdsShowHealth();

    }

    private void Start()
    {
        if (waveControl.waveNumber == WaveNumber.Wave1)
        {
            if (waveControl.saveTutorialCount < 1)
            {
                gameplayTutorial.SetActive(true);
            }
            else
            {
                gameplayTutorial.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (gameplayTutorial.activeInHierarchy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameplayTutorial.SetActive(false);
            }
        }
    }
}