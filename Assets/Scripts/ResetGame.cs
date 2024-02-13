using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private int waveCount = 1;
    
    public TextMeshProUGUI gunLevelText;
    public TextMeshProUGUI gunPriceText;
    private int gunPriceInt = 330;
    private int gunPowerCount = 2;
    
    public TextMeshProUGUI rateFireLevelText;
    public TextMeshProUGUI rateFirePriceText;
    private int rateFirePriceInt = 330;
    private int rateFireCount = 2;
    
    public TextMeshProUGUI sizeBallLevelText;
    public TextMeshProUGUI sizeBallPriceText;
    private int sizeBallCount = 2;
    private int sizeBallPriceInt = 330;

    public Bullet bullet;
    public PlayerFire playerFire;

    public void ResetSetPlayerPrefs()
    {
        bullet.bulletLevel = BulletLevel.Lvl1;
        bullet.bulletRateFire = BulletRateFire.FireLvl1;
        bullet.bulletSize = BulletSize.Size1;
        bullet.transform.localScale = new Vector3(.4f, .4f,.4f);
        playerFire.spawnInterval = .35f;
        
        
        waveCount = 1;
        GameEconomy.sCoinCount = 0;
        gunPowerCount = 2;
        rateFireCount = 2;
        sizeBallCount = 2; 
        
        gunPriceInt =330;
        rateFirePriceInt = 330;
        sizeBallPriceInt = 330;
        
        gunLevelText.text = "Lvl2";
        rateFireLevelText.text = " Lvl2";
        sizeBallLevelText.text = "Lvl2";

        gunPriceText.text =  "330";
        rateFirePriceText.text = "330";
        sizeBallPriceText.text = "330";

        
        PlayerPrefs.SetInt("CountCoin6", GameEconomy.sCoinCount);
        PlayerPrefs.SetInt("waveCount", waveCount);

        PlayerPrefs.SetInt("GunPowerCount16", gunPowerCount);
        PlayerPrefs.SetInt("RateFireCount16", rateFireCount);
        PlayerPrefs.SetInt("SizeBallCount16", sizeBallCount);

        PlayerPrefs.SetInt("GunPriceInt16", gunPriceInt);
        PlayerPrefs.SetInt("RateFirePriceInt16", rateFirePriceInt);
        PlayerPrefs.SetInt("SizeBallPriceInt16", sizeBallPriceInt);

        PlayerPrefs.SetString("gunLevelText16", gunLevelText.text);
        PlayerPrefs.SetString("rateFireLevelText16", rateFireLevelText.text);
        PlayerPrefs.SetString("sizeBallLevelText16", sizeBallLevelText.text);

        PlayerPrefs.SetString("gunPriceText16", gunPriceText.text);
        PlayerPrefs.SetString("rateFirePriceText16", rateFirePriceText.text);
        PlayerPrefs.SetString("sizeBallPriceText16", sizeBallPriceText.text);


        PlayerPrefs.Save();
        
        
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetGetPlayerPrefs()
    {
        GameEconomy.sCoinCount = PlayerPrefs.GetInt("CountCoin6");
        waveCount = PlayerPrefs.GetInt("waveCount");


        gunPowerCount = PlayerPrefs.GetInt("GunPowerCount16", 2);
        rateFireCount = PlayerPrefs.GetInt("RateFireCount16", 2);
        sizeBallCount = PlayerPrefs.GetInt("SizeBallCount16", 2);

        gunPriceInt = PlayerPrefs.GetInt("GunPriceInt16", 330);
        rateFirePriceInt = PlayerPrefs.GetInt("RateFirePriceInt16", 330);
        sizeBallPriceInt = PlayerPrefs.GetInt("SizeBallPriceInt16", 330);

        gunLevelText.text = PlayerPrefs.GetString("gunLevelText16", "Lvl2");
        rateFireLevelText.text = PlayerPrefs.GetString("rateFireLevelText16", "Lvl2");
        sizeBallLevelText.text = PlayerPrefs.GetString("sizeBallLevelText16", "Lvl2");

        gunPriceText.text = PlayerPrefs.GetString("gunPriceText16", "330");
        rateFirePriceText.text = PlayerPrefs.GetString("rateFirePriceText16", "330");
        sizeBallPriceText.text = PlayerPrefs.GetString("sizeBallPriceText16", "330");
    }
}