using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class AddMoneyButton : MonoBehaviour
{
    public GameObject adsPanel;
    public GameObject tutorialHealthAds;
    public WaveControl waveControl;   
    public GameObject gameplayTutorial;
    [Header("None")]
    public FloatingJoystick floatingJoystick;
    public GameObject player;
    public void AddPanelClose()
    {
        adsPanel.SetActive(false);
        player.GetComponent<PlayerController>().floatingJoystick = floatingJoystick;
        floatingJoystick.gameObject.SetActive(true);
    }

    public void AddHealthPanelClose()
    {
        tutorialHealthAds.SetActive(false);
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
