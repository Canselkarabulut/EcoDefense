using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveControl : MonoBehaviour
{
    public WaveNumber waveNumber;
    public TextMeshProUGUI totalEnemyText;
    [HideInInspector] public int enemyLimit;
    private float _timer;
    public float _countdownNum = 10;
    [HideInInspector]public bool isWaveWait = false;
    public TextMeshProUGUI countdownText ;
    private void Start()
    {
        EnemyText();
    }
    private void Update()
    {
        WaveWaitTime();
    }
    public WaveNumber WaveNumberReturn()
    {
        return waveNumber;
    }

    public void EnemyText()
    {
        switch (waveNumber)
        {
            case WaveNumber.Wave1:
                EnemyTextLimit("12", 12);
                break;
            case WaveNumber.Wave2:
                EnemyTextLimit("14", 14);
                break;
            case WaveNumber.Wave3:
                EnemyTextLimit("16", 16);
                break;
            case WaveNumber.Wave4:
                EnemyTextLimit("18", 18);
                break;
            case WaveNumber.Wave5:
                EnemyTextLimit("20", 20);
                break;
            case WaveNumber.Wave6:
                EnemyTextLimit("22", 22);
                break;
            case WaveNumber.Wave7:
                EnemyTextLimit("4", 4);
                break;
        }
    }

    private void EnemyTextLimit(string _totalEnemyText, int _enemyLimit)
    {
        totalEnemyText.text = _totalEnemyText;
        enemyLimit = _enemyLimit;
    }
 

    public void WaveWaitTime()
    {
        if (isWaveWait)
        {
            countdownText.transform.parent.gameObject.SetActive(true);
            countdownText.gameObject.SetActive(true);
            if (_countdownNum <= 1)
            {
                EnemyText();
                isWaveWait = false;
            }
            else
            {
                _countdownNum -= Time.deltaTime;
                countdownText.text = Convert.ToInt32(_countdownNum).ToString();
            
            }
        }
        else
        { 
            countdownText.transform.parent.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);
        }
    }
}