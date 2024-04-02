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
    private int gunPriceInt = 1038;
    private int gunPowerCount = 2;

    public TextMeshProUGUI rateFireLevelText;
    public TextMeshProUGUI rateFirePriceText;
    private int rateFirePriceInt = 1186;
    private int rateFireCount = 2;

    public TextMeshProUGUI sizeBallLevelText;
    public TextMeshProUGUI sizeBallPriceText;
    private int sizeBallCount = 2;
    private int sizeBallPriceInt = 741;

    public Bullet bullet;
    public PlayerFire playerFire;

    public void ResetSetPlayerPrefs()
    {
        Time.timeScale = 1;
        bullet.bulletLevel = BulletLevel.Lvl1;
        bullet.bulletRateFire = BulletRateFire.FireLvl1;
        bullet.bulletSize = BulletSize.Size1;
        bullet.transform.localScale = new Vector3(.4f, .4f, .4f);
        if (playerFire != null)
            playerFire.spawnInterval = .35f;


        waveCount = 1;
        GameEconomy.sCoinCount = 0;
        gunPowerCount = 2;
        rateFireCount = 2;
        sizeBallCount = 2;

        gunPriceInt = 1038;
        rateFirePriceInt = 1186;
        sizeBallPriceInt = 741;


        gunLevelText.text = "Lvl2";
        rateFireLevelText.text = " Lvl2";
        sizeBallLevelText.text = "Lvl2";
        gunPriceText.text = "1038";
        rateFirePriceText.text = "1186";
        sizeBallPriceText.text = "741";

        PlayerPrefs.SetString("gunLevelText16", gunLevelText.text);
        PlayerPrefs.SetString("rateFireLevelText16", rateFireLevelText.text);
        PlayerPrefs.SetString("sizeBallLevelText16", sizeBallLevelText.text);

        PlayerPrefs.SetString("gunPriceText16", gunPriceText.text);
        PlayerPrefs.SetString("rateFirePriceText16", rateFirePriceText.text);
        PlayerPrefs.SetString("sizeBallPriceText16", sizeBallPriceText.text);

        PlayerPrefs.SetInt("mapAnimCount", 0);

        PlayerPrefs.SetInt("CountCoin6", GameEconomy.sCoinCount);
        PlayerPrefs.SetInt("waveCount", waveCount);

        PlayerPrefs.SetInt("GunPowerCount16", gunPowerCount);
        PlayerPrefs.SetInt("RateFireCount16", rateFireCount);
        PlayerPrefs.SetInt("SizeBallCount16", sizeBallCount);

        PlayerPrefs.SetInt("GunPriceInt16", gunPriceInt);
        PlayerPrefs.SetInt("RateFirePriceInt16", rateFirePriceInt);
        PlayerPrefs.SetInt("SizeBallPriceInt16", sizeBallPriceInt);
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            PlayerPrefs.SetInt("musicNum", 1);
            PlayerPrefs.SetInt("soundNum", 1);
        }
        PlayerPrefs.SetFloat("spawnInterval", .4f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public void ResetGetPlayerPrefs()
    {
        GameEconomy.sCoinCount = PlayerPrefs.GetInt("CountCoin6");
        waveCount = PlayerPrefs.GetInt("waveCount");
        PlayerPrefs.GetInt("mapAnimCount", 0);

        gunPowerCount = PlayerPrefs.GetInt("GunPowerCount16", 2);
        rateFireCount = PlayerPrefs.GetInt("RateFireCount16", 2);
        sizeBallCount = PlayerPrefs.GetInt("SizeBallCount16", 2);

        gunPriceInt = PlayerPrefs.GetInt("GunPriceInt16", 1038);
        rateFirePriceInt = PlayerPrefs.GetInt("RateFirePriceInt16", 1186);
        sizeBallPriceInt = PlayerPrefs.GetInt("SizeBallPriceInt16", 741);

        gunLevelText.text = PlayerPrefs.GetString("gunLevelText16", "Lvl2");
        rateFireLevelText.text = PlayerPrefs.GetString("rateFireLevelText16", "Lvl2");
        sizeBallLevelText.text = PlayerPrefs.GetString("sizeBallLevelText16", "Lvl2");

        gunPriceText.text = PlayerPrefs.GetString("gunPriceText16", "1038");
        rateFirePriceText.text = PlayerPrefs.GetString("rateFirePriceText16", "1186");
        sizeBallPriceText.text = PlayerPrefs.GetString("sizeBallPriceText16", "741");
    }
}