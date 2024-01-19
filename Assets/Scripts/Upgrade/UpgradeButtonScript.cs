using System;
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
    private int sizeBallCount = 2;
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
                bullet.bulletLevel = BulletLevel.Lvl2;

                break;
            case 3:
                gunLevelText.text = "Lvl 3";
                gunPriceText.text = "430";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                bullet.bulletLevel = BulletLevel.Lvl3;
                break;
            case 4:
                gunLevelText.text = "Lvl 4";
                gunPriceText.text = "600";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                bullet.bulletLevel = BulletLevel.Lvl4;
                break;
            case 5:
                gunLevelText.text = "Lvl 5";
                gunPriceText.text = "860";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                bullet.bulletLevel = BulletLevel.Lvl5;
                break;
            case 6:
                gunLevelText.text = "Lvl 6";
                gunPriceText.text = "1160";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                bullet.bulletLevel = BulletLevel.Lvl6;
                break;
            case 7:
                gunLevelText.text = "Lvl 7";
                gunPriceText.text = "1535";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
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
                bullet.transform.localScale = new Vector3(.5f, .5f, .5f);

                break;
            case 3:
                sizeBallLevelText.text = "Lvl 3";
                sizeBallPriceText.text = "430";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size3;
                bullet.transform.localScale = new Vector3(.6f, .6f, .6f);
                break;
            case 4:
                sizeBallLevelText.text = "Lvl 4";
                sizeBallPriceText.text = "600";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size4;
                bullet.transform.localScale = new Vector3(.7f, .7f, .7f);
                break;
            case 5:
                sizeBallLevelText.text = "Lvl 5";
                sizeBallPriceText.text = "860";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size5;
                bullet.transform.localScale = new Vector3(.8f, .8f, .8f);
                break;
            case 6:
                sizeBallLevelText.text = "Lvl 6";
                sizeBallPriceText.text = "1160";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size6;
                bullet.transform.localScale = new Vector3(.9f, .9f, .9f);
                break;
            case 7:
                sizeBallLevelText.text = "Lvl 7";
                sizeBallPriceText.text = "1535";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                bullet.bulletSize = BulletSize.Size7;
                bullet.transform.localScale = new Vector3(1, 1, 1);
                break;
            default:
                Debug.Log("tıklama sayısı kontrol alanın dışına çıktı");
                break;
        }

        SavePlayerPrefs();
    }


    private void Update()
    {
        ButtonInteractable(gunPowerBtn, gunPriceInt);
        ButtonInteractable(rateFireButton, rateFirePriceInt);
        ButtonInteractable(sizeBallButton, sizeBallPriceInt);
    }

    public void ButtonInteractable(Button button, int priceInt)
    {
        if (GameEconomy.sCoinCount > priceInt)
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
        PlayerPrefs.SetInt("CountCoin4",GameEconomy.sCoinCount); 
        
        PlayerPrefs.SetInt("GunPowerCount14", gunPowerCount);
        PlayerPrefs.SetInt("RateFireCount14", rateFireCount);
        PlayerPrefs.SetInt("SizeBallCount14", sizeBallCount);

        PlayerPrefs.SetInt("GunPriceInt14", gunPriceInt);
        PlayerPrefs.SetInt("RateFirePriceInt14", rateFirePriceInt);
        PlayerPrefs.SetInt("SizeBallPriceInt14", sizeBallPriceInt);

        PlayerPrefs.SetString("gunLevelText14", gunLevelText.text);
        PlayerPrefs.SetString("rateFireLevelText14", rateFireLevelText.text);
        PlayerPrefs.SetString("sizeBallLevelText14", sizeBallLevelText.text);

        PlayerPrefs.SetString("gunPriceText14", gunPriceText.text);
        PlayerPrefs.SetString("rateFirePriceText14", rateFirePriceText.text);
        PlayerPrefs.SetString("sizeBallPriceText14", sizeBallPriceText.text);

        

        PlayerPrefs.Save();
    }

    private void LoadPlayerPrefs()
    {
        gunPowerCount = PlayerPrefs.GetInt("GunPowerCount14", 2);
        rateFireCount = PlayerPrefs.GetInt("RateFireCount14", 2);
        sizeBallCount = PlayerPrefs.GetInt("SizeBallCount14", 2);

        gunPriceInt = PlayerPrefs.GetInt("GunPriceInt14", 330);
        rateFirePriceInt = PlayerPrefs.GetInt("RateFirePriceInt14", 330);
        sizeBallPriceInt = PlayerPrefs.GetInt("SizeBallPriceInt14", 330);

        gunLevelText.text = PlayerPrefs.GetString("gunLevelText14", "Lvl2");
        rateFireLevelText.text = PlayerPrefs.GetString("rateFireLevelText14", "Lvl2");
        sizeBallLevelText.text = PlayerPrefs.GetString("sizeBallLevelText14", "Lvl2");

        gunPriceText.text = PlayerPrefs.GetString("gunPriceText14", "330");
        rateFirePriceText.text = PlayerPrefs.GetString("rateFirePriceText14", "330");
        sizeBallPriceText.text = PlayerPrefs.GetString("sizeBallPriceText14", "330");
        
        
    }
}