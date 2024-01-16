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
    public TextMeshProUGUI countdownText;
    public GameObject enemys;
    public GameObject bulletSpawn;
    public ParticleSystem shockWave;
    public GameObject hitEffect;
    public GameObject healthPenguins;
    public EnemySpawn enemySpawn;
    public GameObject fireEffect;
    public TextMeshProUGUI waveText;

    public WaitStatus waitStatus;
    public GameObject upgradeButton;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("waveCount"))
       {
           case 1:
               waveNumber = WaveNumber.Wave1;
               break;
           case 2:
               waveNumber = WaveNumber.Wave2;
               break;
           case 3:
               waveNumber = WaveNumber.Wave3;
               break;
           case 4:
               waveNumber = WaveNumber.Wave4;
               break;
           case 5:
               waveNumber = WaveNumber.Wave5;
               break;
           case 6:
               waveNumber = WaveNumber.Wave6;
               break;
           case 7:
               waveNumber = WaveNumber.Wave7;
               break;
           
       }
       EnemyText();
       waitStatus = WaitStatus.Game;
        
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
                EnemyTextLimit("Wave 1", "12", 12,1);
                break;
            case WaveNumber.Wave2:
                EnemyTextLimit("Wave 2", "14", 14,2);
                break;
            case WaveNumber.Wave3:
                EnemyTextLimit("Wave 3", "16", 16,3);
                break;
            case WaveNumber.Wave4:
                EnemyTextLimit("Wave 4", "18", 18,4);
                break;
            case WaveNumber.Wave5:
                EnemyTextLimit("Wave 5", "20", 20,5);
                break;
            case WaveNumber.Wave6:
                EnemyTextLimit("Wave 6", "22", 22,6);
                break;
            case WaveNumber.Wave7:
                EnemyTextLimit("Wave 7", "10", 10,7);
                break;
        }
    }

    private void EnemyTextLimit(string _waveString, string _totalEnemyText, int _enemyLimit,int waveCount)
    {
        PlayerPrefs.SetInt("waveCount",waveCount);
        totalEnemyText.text = _totalEnemyText;
        enemyLimit = _enemyLimit;
        waveText.text = _waveString;
        ShockWaveEffect();
    }


    public void WaveWaitTime()
    {
      
        if (waitStatus == WaitStatus.GameBreak)
        {
            if (enemys.transform.childCount < 1)
            {
                enemySpawn.enemyCount = 0;
                hitEffect.gameObject.SetActive(false);
                healthPenguins.SetActive(true);
                countdownText.gameObject.SetActive(true);
                countdownText.transform.parent.gameObject.SetActive(true);
                bulletSpawn.SetActive(false);
                upgradeButton.SetActive(true);
                
                if (_countdownNum <= 1)
                {
                    EnemyText();
                    enemySpawn.killEnemyCount = 0;
                    enemySpawn.killEnemyText.text = "0";
                    PlayerPrefs.SetInt("CountCoin",GameEconomy.sCoinCount); // bölüm bittikçe parayı kaydet
                    waitStatus = WaitStatus.Game;
                    switch (waveNumber)
                    {
                        case WaveNumber.Wave1:
                            waveNumber = WaveNumber.Wave2;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                        case WaveNumber.Wave2:
                            waveNumber = WaveNumber.Wave3;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                        case WaveNumber.Wave3:
                            waveNumber = WaveNumber.Wave4;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                        case WaveNumber.Wave4:
                            waveNumber = WaveNumber.Wave5;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                        case WaveNumber.Wave5:
                            waveNumber = WaveNumber.Wave6;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                        case WaveNumber.Wave6:
                            waveNumber = WaveNumber.Wave7;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                        case WaveNumber.Wave7:
                            //win sayfası açılacak
                            waveNumber = WaveNumber.Wave7;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                    }
                }
                else
                {
                    _countdownNum -= Time.deltaTime;
                    countdownText.text = Convert.ToInt32(_countdownNum).ToString();
                }
            }
        }
        else if (waitStatus == WaitStatus.Game) 
        {
            bulletSpawn.SetActive(true);
            healthPenguins.SetActive(false);
            bulletSpawn.SetActive(true);
            hitEffect.gameObject.SetActive(true);
            countdownText.transform.parent.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);
            upgradeButton.SetActive(false);
           
        }
    }

    public void ShockWaveEffect()
    {
        shockWave.gameObject.SetActive(true);
        shockWave.Play();
        fireEffect.SetActive(false);
    }
}