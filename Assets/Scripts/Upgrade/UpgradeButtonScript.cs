using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonScript : MonoBehaviour
{
    public Button gunPowerBtn;
    public TextMeshProUGUI gunLevelText;
    public TextMeshProUGUI gunPriceText;
    [HideInInspector] public int gunPriceInt = 1038;
    [HideInInspector] public int gunPowerCount = 2;


    public Button rateFireButton;
    public TextMeshProUGUI rateFireLevelText;
    public TextMeshProUGUI rateFirePriceText;
    [HideInInspector] public int rateFirePriceInt = 1186;
    [HideInInspector] public int rateFireCount = 2;


    public Button sizeBallButton;
    public TextMeshProUGUI sizeBallLevelText;
    public TextMeshProUGUI sizeBallPriceText;
    [HideInInspector] public int sizeBallCount = 2;
    [HideInInspector] public int sizeBallPriceInt = 741;


    public GameEconomy gameEconomy;
    public PlayerFire playerFire;


    [HideInInspector] public int bulletLevelNumber = 1;
    [HideInInspector] public int bulleSizeNumber = 1;

    public Bullet bullet;
    public GameObject pool;

    private int maxgunPowerButtonClickCount = 8; /*maksimum buton tıklama sayısı 7 olduğu için 8 dedik upgradeler 7 ye kadar ayarlandığından */
    private int maxrateFireButtonClickCount = 8; /*maksimum buton tıklama sayısı 7 olduğu için 8 dedik upgradeler 7 ye kadar ayarlandığından */
    private int maxsizeBalButtonClickCount = 8; /*maksimum buton tıklama sayısı 7 olduğu için 8 dedik upgradeler 7 ye kadar ayarlandığından */


    private void Start()
    {
        LoadPlayerPrefs();
    }


    public void GunPowerBtn()
    {
        GameEconomy.sCoinCount -= gunPriceInt;
        gameEconomy.CoinText();
        gunPowerCount++;
        switch (gunPowerCount)
        {
            case 2:
                gunLevelText.text = "Lvl 2";
                gunPriceText.text = "1038";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().bulletLevel = BulletLevel.Lvl2;
                    }
                }

                bullet.bulletLevel = BulletLevel.Lvl2;
                break;
            case 3:
                gunLevelText.text = "Lvl 3";
                gunPriceText.text = "1482";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().bulletLevel = BulletLevel.Lvl3;
                    }
                }

                bullet.bulletLevel = BulletLevel.Lvl3;
                break;
            case 4:
                gunLevelText.text = "Lvl 4";
                gunPriceText.text = "1866";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().bulletLevel = BulletLevel.Lvl4;
                    }
                }

                bullet.bulletLevel = BulletLevel.Lvl4;
                break;
            case 5:
                gunLevelText.text = "Lvl 5";
                gunPriceText.text = "2310";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().bulletLevel = BulletLevel.Lvl5;
                    }
                }

                bullet.bulletLevel = BulletLevel.Lvl5;
                break;
            case 6:
                gunLevelText.text = "Lvl 6";
                gunPriceText.text = "2636";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().bulletLevel = BulletLevel.Lvl6;
                    }
                }

                bullet.bulletLevel = BulletLevel.Lvl6;
                break;
            case 7:
                gunLevelText.text = "Lvl 7";
                gunPriceText.text = "3586";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().bulletLevel = BulletLevel.Lvl7;
                    }
                }

                bullet.bulletLevel = BulletLevel.Lvl7;
                break;
            case 8:
                gunLevelText.text = "Max";
                gunPriceText.text = "Max";
                break;
            default:
                break;
        }

        SavePlayerPrefs();
    }

    public void RateOfFireButton()
    {
        GameEconomy.sCoinCount -= rateFirePriceInt;
        gameEconomy.CoinText();
        rateFireCount++;
        switch (rateFireCount)
        {
            case 2:
                rateFireLevelText.text = "Lvl 2";
                rateFirePriceText.text = "1186";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);

                bullet.bulletRateFire = BulletRateFire.FireLvl2;
                PlayerPrefs.SetFloat("spawnInterval", .35f);
                playerFire.spawnInterval = .35f;
                break;
            case 3:
                rateFireLevelText.text = "Lvl 3";
                rateFirePriceText.text = "1694";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl3;
                PlayerPrefs.SetFloat("spawnInterval", .3f);
                playerFire.spawnInterval = .3f;
                break;
            case 4:
                rateFireLevelText.text = "Lvl 4";
                rateFirePriceText.text = "2132";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl4;
                PlayerPrefs.SetFloat("spawnInterval", .25f);
                playerFire.spawnInterval = .25f;
                break;
            case 5:
                rateFireLevelText.text = "Lvl 5";
                rateFirePriceText.text = "2640";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl5;
                PlayerPrefs.SetFloat("spawnInterval", .2f);
                playerFire.spawnInterval = .2f;
                break;
            case 6:
                rateFireLevelText.text = "Lvl 6";
                rateFirePriceText.text = "3012";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl6;
                PlayerPrefs.SetFloat("spawnInterval", .15f);
                playerFire.spawnInterval = .15f;
                break;
            case 7:
                rateFireLevelText.text = "Lvl 7";
                rateFirePriceText.text = "3138";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl7;
                PlayerPrefs.SetFloat("spawnInterval", .1f);
                playerFire.spawnInterval = 0.1f;
                break;
            case 8:
                rateFireLevelText.text = "Max";
                rateFirePriceText.text = "Max";
                break;
            default:
                break;
        }


        SavePlayerPrefs();
    }

    public void SizeBallButton()
    {
        GameEconomy.sCoinCount -= sizeBallPriceInt;
        gameEconomy.CoinText();
        sizeBallCount++;
        switch (sizeBallCount)
        {
            case 2:
                sizeBallLevelText.text = "Lvl 2";
                sizeBallPriceText.text = "741";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.5f, .5f, .5f);
                    }
                }

                bullet.bulletSize = BulletSize.Size2;
                bullet.transform.localScale =
                    new Vector3(.5f, .5f, .5f);
                break;
            case 3:
                sizeBallLevelText.text = "Lvl 3";
                sizeBallPriceText.text = "1059";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);

                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.6f, .6f, .6f);
                    }
                }

                bullet.bulletSize = BulletSize.Size3;
                bullet.transform.localScale =
                    new Vector3(.6f, .6f, .6f);
                break;
            case 4:
                sizeBallLevelText.text = "Lvl 4";
                sizeBallPriceText.text = "1333";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);

                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.7f, .7f, .7f);
                    }
                }

                bullet.bulletSize = BulletSize.Size4;
                bullet.transform.localScale =
                    new Vector3(.7f, .7f, .7f);
                break;
            case 5:
                sizeBallLevelText.text = "Lvl 5";
                sizeBallPriceText.text = "1650";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size5;
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.8f, .8f, .8f);
                    }
                }

                bullet.bulletSize = BulletSize.Size5;
                bullet.transform.localScale =
                    new Vector3(.8f, .8f, .8f);
                break;
            case 6:
                sizeBallLevelText.text = "Lvl 6";
                sizeBallPriceText.text = "1883";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);

                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.9f, .9f, .9f);
                    }
                }

                bullet.bulletSize = BulletSize.Size6;
                bullet.transform.localScale =
                    new Vector3(.9f, .9f, .9f);

                break;
            case 7:
                sizeBallLevelText.text = "Lvl 7";
                sizeBallPriceText.text = "2241";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);

                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale = new Vector3(1, 1, 1);
                    }
                }

                bullet.bulletSize = BulletSize.Size7;
                bullet.transform.localScale =
                    new Vector3(1, 1, 1);
                break;
            case 8:
                sizeBallLevelText.text = "Max";
                sizeBallPriceText.text = "Max";
                sizeBallButton.interactable = false;
                break;
            default:
                break;
        }


        SavePlayerPrefs();
    }

    private void Update()
    {
        ButtonInteractable(gunPowerBtn, gunPriceInt, gunPowerCount,maxgunPowerButtonClickCount);
        ButtonInteractable(rateFireButton, rateFirePriceInt, rateFireCount,maxgunPowerButtonClickCount);
        ButtonInteractable(sizeBallButton, sizeBallPriceInt, sizeBallCount,maxsizeBalButtonClickCount);
    }

    public void ButtonInteractable(Button button, int priceInt, int count ,int maxButtonClickCount )
    {
        if (GameEconomy.sCoinCount > priceInt - 1)
        {
            button.interactable = true;
           
        }
        else
        {
            button.interactable = false;
        }
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("CountCoin6", GameEconomy.sCoinCount);

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
    }

    public void LoadPlayerPrefs()
    {
        gunPowerCount = PlayerPrefs.GetInt("GunPowerCount16");
        rateFireCount = PlayerPrefs.GetInt("RateFireCount16");
        sizeBallCount = PlayerPrefs.GetInt("SizeBallCount16");

        gunPriceInt = PlayerPrefs.GetInt("GunPriceInt16");
        rateFirePriceInt = PlayerPrefs.GetInt("RateFirePriceInt16");
        sizeBallPriceInt = PlayerPrefs.GetInt("SizeBallPriceInt16");

        gunLevelText.text = PlayerPrefs.GetString("gunLevelText16", "Lvl2");
        rateFireLevelText.text = PlayerPrefs.GetString("rateFireLevelText16", "Lvl2");
        sizeBallLevelText.text = PlayerPrefs.GetString("sizeBallLevelText16", "Lvl2");

        gunPriceText.text = PlayerPrefs.GetString("gunPriceText16", "1038");
        rateFirePriceText.text = PlayerPrefs.GetString("rateFirePriceText16", "1186");
        sizeBallPriceText.text = PlayerPrefs.GetString("sizeBallPriceText16", "741");

        playerFire.spawnInterval = PlayerPrefs.GetFloat("spawnInterval");
    }
}