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
    private int playerCoin;
    private int gunPowerButtonCoin;
    private int rateofFireButtonCoin;
    private int sizeBallButtonCoin;
    public bool isActive = false;
    public GameObject warningHand;

    private void Start()
    {
        gameUpgradePanel.SetActive(false);
        gameControl.SetActive(true);
        Time.timeScale = 1;
        playerCoin = GameEconomy.sCoinCount; // oyuncunun parasına bak
        gunPowerButtonCoin = upgradeButtonScript.gunPriceInt;
        rateofFireButtonCoin = upgradeButtonScript.rateFirePriceInt;
        sizeBallButtonCoin = upgradeButtonScript.sizeBallPriceInt;
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
        UpgradeActiveEffect(warningHand, gunPowerButtonCoin);
        UpgradeActiveEffect(warningHand, rateofFireButtonCoin);
        UpgradeActiveEffect(warningHand, sizeBallButtonCoin);
    }

    public void UpgradeActiveEffect(GameObject warningHand, int priceInt)
    {
        if (GameEconomy.sCoinCount >= priceInt - 1)
        {
            //efekti aktifleştir
            warningHand.SetActive(true);
            warningHand.GetComponent<Animator>().Play("warningHands");
        }
        else
        {
            warningHand.SetActive(false);
        }
    }

    public void OpenPanelWarning() //Upgrade paneli açmayı uyarması
    {
        if (playerCoin >= gunPowerButtonCoin || playerCoin >= rateofFireButtonCoin || playerCoin >= sizeBallButtonCoin)
        {
            //butonun üstüne tıklamayı belirten el çıkacak
            Debug.Log("elçıktı");
        }

        if (playerCoin < gunPowerButtonCoin && playerCoin < rateofFireButtonCoin && playerCoin < sizeBallButtonCoin)
        {
            //el kapalı kalacak
            Debug.Log("elkapalı");
            warningHand.SetActive(false);
        }
        // var gunPowerButtonCoin = 
        // oyuncunun parasına bak
        //upgrade buttonlarının parasına baj
        //oyuncunun parası upgrade buttonlarının parasından eşit veya büyükse kullanıcıya hatırlatmak için el çıksın
    }
}