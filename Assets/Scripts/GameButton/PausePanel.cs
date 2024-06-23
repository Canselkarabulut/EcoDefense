using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameObject gameControl;
    public Button upgradeButton;
    public Button pauseButton;
    public GameObject tutorialUpgrade;
    public GameObject tutorialAds;
    public WaveControl waveControl;
  
    
    public void PausePanelClose()
    {
        Time.timeScale = 1;
   
        if (gameObject != null)
            gameControl.SetActive(true);
        upgradeButton.interactable = true;
        //upgradeButton.GetComponent<UpgradeButton>().isActive = false;
     //   upgradeButton.GetComponent<UpgradeButton>().warningHand.SetActive(false);
        pauseButton.interactable = true;
        if (waveControl != null)
        {
            if (waveControl.waveNumber == WaveNumber.Wave1)
            {
                if (waveControl.saveTutorialCount == 1)
                {
                    if (tutorialUpgrade != null)
                    {
                        tutorialUpgrade.SetActive(false);
                    }
                    if (tutorialAds != null)
                    {
                        //ilk halse
                        tutorialAds.SetActive(true);
                        upgradeButton.interactable = false;
                        waveControl.saveTutorialCount++;

                    }
                }
            }
        }
        gameObject.SetActive(false);
       

       
    }
}