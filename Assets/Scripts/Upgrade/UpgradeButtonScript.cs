using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButtonScript : MonoBehaviour
{
    //  public Button gunPowerBtn;
    //  public Button rateFireButton;
    //  public Button sizeBallButton;
//
    //  public TextMeshProUGUI gunLevelText;
    //  public TextMeshProUGUI rateFireLevelText;
    //  public TextMeshProUGUI sizeBallLevelText;
//
    //  public TextMeshProUGUI gunPriceText;
    //  public TextMeshProUGUI rateFirePriceText;
    //  public TextMeshProUGUI sizeBallPriceText;
//
    //  private int gunPowerCount = 2;
    //  private int rateFireCount = 2;
    //  private int sizeBallCount = 2;
//
    //  private int gunPriceInt = 330;
    //  private int rateFirePriceInt = 330;
    //  private int sizeBallPriceInt = 330;
//
    //  public GameEconomy gameEconomy;
//
    //  private void Start()
    //  {
    //   //   LoadPlayerPrefs();
    //      UpdateButtonUI(gunPowerBtn, gunPowerCount, gunLevelText, gunPriceText, gunPriceInt);
    //      UpdateButtonUI(rateFireButton, rateFireCount, rateFireLevelText, rateFirePriceText, rateFirePriceInt);
    //      UpdateButtonUI(sizeBallButton, sizeBallCount, sizeBallLevelText, sizeBallPriceText, sizeBallPriceInt);
    //  }
//
    //  public void GunPowerButton()
    //  {
    //      UpgradeButtonControl(gunPowerBtn, ref gunPowerCount, gunLevelText, gunPriceText, ref gunPriceInt);
    //    //  SavePlayerPrefs();
    //  }
//
    //  public void RateOfFireButton()
    //  {
    //      UpgradeButtonControl(rateFireButton, ref rateFireCount, rateFireLevelText, rateFirePriceText,
    //          ref rateFirePriceInt);
    //   //   SavePlayerPrefs();
    //  }
//
    //  public void SizeBallButton()
    //  {
    //      UpgradeButtonControl(sizeBallButton, ref sizeBallCount, sizeBallLevelText, sizeBallPriceText,
    //          ref sizeBallPriceInt);
    //   //   SavePlayerPrefs();
    //  }
//
    //  private void UpgradeButtonControl(Button button, ref int count, TextMeshProUGUI levelText,
    //      TextMeshProUGUI priceText,
    //      ref int priceInt)
    //  {
    //      if (GameEconomy.sCoinCount >= priceInt)
    //      {
    //          GameEconomy.sCoinCount -= priceInt;
    //          gameEconomy.CoinText();
//
    //          count++;
    //          UpdateButtonUI(button, count, levelText, priceText, priceInt);
    //      }
    //      // else: Not enough coins, handle this situation if needed
    //  }
//
    //  private void UpdateButtonUI(Button button, int count, TextMeshProUGUI levelText, TextMeshProUGUI priceText,
    //      int priceInt)
    //  {
    //      switch (count)
    //      {
    //          case 2:
    //              levelText.text = "Lvl 2";
    //              priceText.text = "330";
    //              break;
    //          case 3:
    //              levelText.text = "Lvl 3";
    //              priceText.text = "430";
    //              break;
    //          case 4:
    //              levelText.text = "Lvl 4";
    //              priceText.text = "600";
    //              break;
    //          case 5:
    //              levelText.text = "Lvl 5";
    //              priceText.text = "860";
    //              break;
    //          case 6:
    //              levelText.text = "Lvl 6";
    //              priceText.text = "1160";
    //              break;
    //          case 7:
    //              levelText.text = "Lvl 7";
    //              priceText.text = "1535";
    //              break;
    //          default:
    //              button.interactable=false;
    //              break;
    //      }
//
    //      priceInt = int.Parse(priceText.text);
    //      UpdateButtonInteractivity();
    //  }
//
    //  private void UpdateButtonInteractivity()
    //  {
    //      gunPowerBtn.interactable = (GameEconomy.sCoinCount >= gunPriceInt);
    //      rateFireButton.interactable = (GameEconomy.sCoinCount >= rateFirePriceInt);
    //      sizeBallButton.interactable = (GameEconomy.sCoinCount >= sizeBallPriceInt);
    //  }
//
    ////  private void SavePlayerPrefs()
    ////  {
    ////      PlayerPrefs.SetInt("GunPowerCount3", gunPowerCount);
    ////      PlayerPrefs.SetInt("RateFireCount3", rateFireCount);
    ////      PlayerPrefs.SetInt("SizeBallCount3", sizeBallCount);
////
    ////      PlayerPrefs.SetInt("GunPriceInt3", gunPriceInt);
    ////      PlayerPrefs.SetInt("RateFirePriceInt3", rateFirePriceInt);
    ////      PlayerPrefs.SetInt("SizeBallPriceInt3", sizeBallPriceInt);
////
    ////      PlayerPrefs.Save();
    ////  }
////
    ////  private void LoadPlayerPrefs()
    ////  {
    ////      gunPowerCount = PlayerPrefs.GetInt("GunPowerCount3", 2);
    ////      rateFireCount = PlayerPrefs.GetInt("RateFireCount3", 2);
    ////      sizeBallCount = PlayerPrefs.GetInt("SizeBallCount3", 2);
////
    ////      gunPriceInt = PlayerPrefs.GetInt("GunPriceInt3", 330);
    ////      rateFirePriceInt = PlayerPrefs.GetInt("RateFirePriceInt3", 330);
    ////      sizeBallPriceInt = PlayerPrefs.GetInt("SizeBallPriceInt3", 330);
    ////  }


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

                break;
            case 3:
                gunLevelText.text = "Lvl 3";
                gunPriceText.text = "430";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                break;
            case 4:
                gunLevelText.text = "Lvl 4";
                gunPriceText.text = "600";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                break;
            case 5:
                gunLevelText.text = "Lvl 5";
                gunPriceText.text = "860";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                break;
            case 6:
                gunLevelText.text = "Lvl 6";
                gunPriceText.text = "1160";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
                break;
            case 7:
                gunLevelText.text = "Lvl 7";
                gunPriceText.text = "1535";
                gunPriceInt = Convert.ToInt32(gunPriceText.text);
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

                break;
            case 3:
                rateFireLevelText.text = "Lvl 3";
                rateFirePriceText.text = "430";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                break;
            case 4:
                rateFireLevelText.text = "Lvl 4";
                rateFirePriceText.text = "600";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                break;
            case 5:
                rateFireLevelText.text = "Lvl 5";
                rateFirePriceText.text = "860";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                break;
            case 6:
                rateFireLevelText.text = "Lvl 6";
                rateFirePriceText.text = "1160";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
                break;
            case 7:
                rateFireLevelText.text = "Lvl 7";
                rateFirePriceText.text = "1535";
                rateFirePriceInt = Convert.ToInt32(rateFirePriceText.text);
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

                break;
            case 3:
                sizeBallLevelText.text = "Lvl 3";
                sizeBallPriceText.text = "430";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                break;
            case 4:
                sizeBallLevelText.text = "Lvl 4";
                sizeBallPriceText.text = "600";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                break;
            case 5:
                sizeBallLevelText.text = "Lvl 5";
                sizeBallPriceText.text = "860";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                break;
            case 6:
                sizeBallLevelText.text = "Lvl 6";
                sizeBallPriceText.text = "1160";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
                break;
            case 7:
                sizeBallLevelText.text = "Lvl 7";
                sizeBallPriceText.text = "1535";
                sizeBallPriceInt = Convert.ToInt32(sizeBallPriceText.text);
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
            Debug.Log("true");
        }
        else
        {
            button.interactable = false;

            Debug.Log("false");
        }
    }


    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("CountCoin",GameEconomy.sCoinCount); 
        
        PlayerPrefs.SetInt("GunPowerCount8", gunPowerCount);
        PlayerPrefs.SetInt("RateFireCount8", rateFireCount);
        PlayerPrefs.SetInt("SizeBallCount8", sizeBallCount);

        PlayerPrefs.SetInt("GunPriceInt8", gunPriceInt);
        PlayerPrefs.SetInt("RateFirePriceInt8", rateFirePriceInt);
        PlayerPrefs.SetInt("SizeBallPriceInt8", sizeBallPriceInt);

        PlayerPrefs.SetString("gunLevelText8", gunLevelText.text);
        PlayerPrefs.SetString("rateFireLevelText8", rateFireLevelText.text);
        PlayerPrefs.SetString("sizeBallLevelText8", sizeBallLevelText.text);

        PlayerPrefs.SetString("gunPriceText8", gunPriceText.text);
        PlayerPrefs.SetString("rateFirePriceText8", rateFirePriceText.text);
        PlayerPrefs.SetString("sizeBallPriceText8", sizeBallPriceText.text);


        PlayerPrefs.Save();
    }

    private void LoadPlayerPrefs()
    {
        gunPowerCount = PlayerPrefs.GetInt("GunPowerCount8", 2);
        rateFireCount = PlayerPrefs.GetInt("RateFireCount8", 2);
        sizeBallCount = PlayerPrefs.GetInt("SizeBallCount8", 2);

        gunPriceInt = PlayerPrefs.GetInt("GunPriceInt8", 330);
        rateFirePriceInt = PlayerPrefs.GetInt("RateFirePriceInt8", 330);
        sizeBallPriceInt = PlayerPrefs.GetInt("SizeBallPriceInt8", 330);

        gunLevelText.text = PlayerPrefs.GetString("gunLevelText8", "Lvl2");
        rateFireLevelText.text = PlayerPrefs.GetString("rateFireLevelText8", "Lvl2");
        sizeBallLevelText.text = PlayerPrefs.GetString("sizeBallLevelText8", "Lvl2");

        gunPriceText.text = PlayerPrefs.GetString("gunPriceText8", "330");
        rateFirePriceText.text = PlayerPrefs.GetString("rateFirePriceText8", "330");
        sizeBallPriceText.text = PlayerPrefs.GetString("sizeBallPriceText8", "330");
    }
}