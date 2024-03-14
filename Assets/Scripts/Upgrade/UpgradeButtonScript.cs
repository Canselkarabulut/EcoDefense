using System;
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
    private int gunPriceInt = 330;
    private int gunPowerCount = 2;


    public Button rateFireButton;
    public TextMeshProUGUI rateFireLevelText;
    public TextMeshProUGUI rateFirePriceText;
    private int rateFirePriceInt = 330;
    private int rateFireCount = 2;


    public Button sizeBallButton;
    public TextMeshProUGUI sizeBallLevelText;
    public TextMeshProUGUI sizeBallPriceText;
    public int sizeBallCount = 2;
    private int sizeBallPriceInt = 330;


    public GameEconomy gameEconomy;
    public PlayerFire playerFire;


    private int bulletLevelNumber = 1;
    private int bulleSizeNumber = 1;

    public Bullet bullet;

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
                gunPriceText.text = "330";
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
                gunPriceText.text = "430";
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
                gunPriceText.text = "600";
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
                gunPriceText.text = "860";
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
                gunPriceText.text = "1160";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);  for (int i = 0; i < pool.transform.childCount; i++)
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
                gunPriceText.text = "1535";
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
            default:
                Debug.Log("tıklama sayısı kontrol alanın dışına çıktı");
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
                rateFirePriceText.text = "330";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl2;
                playerFire.spawnInterval = .35f;
                break;
            case 3:
                rateFireLevelText.text = "Lvl 3";
                rateFirePriceText.text = "430";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl3;
                playerFire.spawnInterval = .3f;
                break;
            case 4:
                rateFireLevelText.text = "Lvl 4";
                rateFirePriceText.text = "600";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl4;
                playerFire.spawnInterval = .25f;
                break;
            case 5:
                rateFireLevelText.text = "Lvl 5";
                rateFirePriceText.text = "860";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl5;
                playerFire.spawnInterval = .2f;
                break;
            case 6:
                rateFireLevelText.text = "Lvl 6";
                rateFirePriceText.text = "1160";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl6;
                playerFire.spawnInterval = .15f;
                break;
            case 7:
                rateFireLevelText.text = "Lvl 7";
                rateFirePriceText.text = "1535";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                bullet.bulletRateFire = BulletRateFire.FireLvl7;
                playerFire.spawnInterval = 0.1f;
                break;
            default:
                Debug.Log("tıklama sayısı kontrol alanın dışına çıktı");
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
                sizeBallPriceText.text = "330";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size2;
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.5f, .5f, .5f);
                    }
                }


                break;
            case 3:
                sizeBallLevelText.text = "Lvl 3";
                sizeBallPriceText.text = "430";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size3;
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.6f, .6f, .6f);
                    }
                }

                break;
            case 4:
                sizeBallLevelText.text = "Lvl 4";
                sizeBallPriceText.text = "600";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size4;
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.7f, .7f, .7f);
                    }
                }

                break;
            case 5:
                sizeBallLevelText.text = "Lvl 5";
                sizeBallPriceText.text = "860";
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

                break;
            case 6:
                sizeBallLevelText.text = "Lvl 6";
                sizeBallPriceText.text = "1160";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size6;
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale =
                            new Vector3(.9f, .9f, .9f);
                    }
                }

                break;
            case 7:
                sizeBallLevelText.text = "Lvl 7";
                sizeBallPriceText.text = "1535";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size7;
                for (int i = 0; i < pool.transform.childCount; i++)
                {
                    if (pool.transform.GetChild(i).GetComponent<Bullet>())
                    {
                        pool.transform.GetChild(i).GetComponent<Bullet>().transform.localScale = new Vector3(1, 1, 1);
                    }
                }

                break;
            case 8:
                sizeBallButton.interactable = false;
                Debug.Log("kapanma");
                break;
            default:
                Debug.Log("tıklama sayısı kontrol alanın dışına çıktı");
                break;
        }


        SavePlayerPrefs();
    }

    public GameObject pool;

    private void Update()
    {
        ButtonInteractable(gunPowerBtn, gunPriceInt,gunPowerCount);
        ButtonInteractable(rateFireButton, rateFirePriceInt,rateFireCount);
        ButtonInteractable(sizeBallButton, sizeBallPriceInt,sizeBallCount);
    }

    private int maxButtonClickCount = 8;/*maksimum buton tıklama sayısı 7 olduğu için 8 dedik upgradeler 7 ye kadar ayarlandığından */
    public void ButtonInteractable(Button button, int priceInt , int count)
    {
        if (GameEconomy.sCoinCount > priceInt-1 && count<maxButtonClickCount)
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