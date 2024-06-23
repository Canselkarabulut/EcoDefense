using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdsShowControl : MonoBehaviour
{
    public AdsManager adsManager;
    [Header("MoneyAds")] public int additionalMoneyCount = 2;
    public TextMeshProUGUI additionalMoneyCountText;
    public GameEconomy gameEconomy;
    public Animator coinAnim;
    public GameObject adsMoneyButton;
    [Header("HealthAds")]
    public GameObject showRewardedAdsButton;
    public PlayerTrigger playerTrigger;

    public void AdsShow()
    {
        if (!adsManager.isAdsShownRewarded)
        {
            additionalMoneyCount--;
            additionalMoneyCountText.text = additionalMoneyCount.ToString();
            
                
            if (additionalMoneyCount == 0)
            {
                adsMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
                additionalMoneyCount = 2;
                additionalMoneyCountText.text = additionalMoneyCount.ToString();
            }
            
            GameEconomy.sCoinCount += 200;
            gameEconomy.CoinText();
            coinAnim.SetBool("isCoinAdd", true);
        }
    }
  
    public void AdsShowHealth()
    {
        if (!adsManager.isAdsShownRewardedHealth)
        {
            
            showRewardedAdsButton.SetActive(false); // ödüllü reklamı açan buton kapandı
            playerTrigger.healthBar.GetComponent<Renderer>().material = playerTrigger.healthbarGreen;
            playerTrigger.healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
        }
    }
}
