using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEconomy : MonoBehaviour
{
    public static int sCoinCount;
    public TextMeshProUGUI coinText;

    public void CoinCount(int countCoin)
    {
        sCoinCount += countCoin;
        coinText.text = sCoinCount.ToString();

    }
    
}
