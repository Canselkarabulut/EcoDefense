using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{
    public static int sCoinCount;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        sCoinCount = PlayerPrefs.GetInt("CountCoin6");
     
        coinText.text = sCoinCount.ToString();
    }

    public void CoinCount(int countCoin)
    {
        sCoinCount += countCoin;
        coinText.text = sCoinCount.ToString();
    }

    public void CoinText()
    {
        coinText.text = sCoinCount.ToString();
    }
    
}
