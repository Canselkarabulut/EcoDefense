using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public GameObject gameUpgradePanel;
    public GameObject gameControl;
    public Button pausePanel;

    public UpgradeButtonScript upgradeButtonScript;
    public GameObject warninUgpgradeEffect;
    public Animator upgradeButton;

    private void Start()
    {
        gameUpgradePanel.SetActive(false);
        gameControl.SetActive(true);
        Time.timeScale = 1;
    }

    public void Upgrade()
    {
        gameControl.SetActive(false);
        gameUpgradePanel.SetActive(true);
        pausePanel.interactable = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        UpgradeActiveEffect(warninUgpgradeEffect, upgradeButtonScript.gunPriceInt);
        UpgradeActiveEffect(warninUgpgradeEffect, upgradeButtonScript.rateFirePriceInt);
        UpgradeActiveEffect(warninUgpgradeEffect, upgradeButtonScript.sizeBallPriceInt);
    }

    public void UpgradeActiveEffect(GameObject warningEffect, int priceInt)
    {
        if (GameEconomy.sCoinCount >= priceInt - 1)
        {
            upgradeButton.SetBool("isButtonActive",true);
            warningEffect.SetActive(true);
            
            
        }
        else
        {
            upgradeButton.SetBool("isButtonActive",false);
            warningEffect.SetActive(false);
        }
    }
}