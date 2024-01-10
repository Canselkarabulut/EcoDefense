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
 //   [HideInInspector] public bool isWaveWait = false;
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

    private void Start()
    {
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
                EnemyTextLimit("Wave 1", "12", 13);
                break;
            case WaveNumber.Wave2:
                EnemyTextLimit("Wave 2", "14", 15);
                break;
            case WaveNumber.Wave3:
                EnemyTextLimit("Wave 3", "16", 17);
                break;
            case WaveNumber.Wave4:
                EnemyTextLimit("Wave 4", "18", 19);
                break;
            case WaveNumber.Wave5:
                EnemyTextLimit("Wave 5", "20", 21);
                break;
            case WaveNumber.Wave6:
                EnemyTextLimit("Wave 6", "22", 23);
                break;
            case WaveNumber.Wave7:
                EnemyTextLimit("Wave 7", "4", 5);
                break;
        }
    }

    private void EnemyTextLimit(string _waveString, string _totalEnemyText, int _enemyLimit)
    {
        totalEnemyText.text = _totalEnemyText;
        enemyLimit = _enemyLimit;
        waveText.text = _waveString;
        ShockWaveEffect();
    }

    public void WaveWaitTime()
    {
        if (waitStatus == WaitStatus.GameBreak) //oyun arası
        {
            if (enemys.transform.childCount < 1)
            {
                countdownText.transform.parent.gameObject.SetActive(true);
                bulletSpawn.SetActive(false);
                hitEffect.gameObject.SetActive(false);
                healthPenguins.SetActive(true);
                countdownText.gameObject.SetActive(true);
                if (_countdownNum <= 1)
                {
                    EnemyText();
                    enemySpawn.killEnemyCount = 0;
                    enemySpawn.killEnemyText.text = "0";
                    // enemySpawn.enemyCount = 0;
                    waitStatus = WaitStatus.Game;
                   // isWaveWait = false;
                }
                else
                {
                    _countdownNum -= Time.deltaTime;
                    countdownText.text = Convert.ToInt32(_countdownNum).ToString();
                }
            }
        }
        else if (waitStatus == WaitStatus.Game) //oyun
        {
            healthPenguins.SetActive(false);
            bulletSpawn.SetActive(true);
            hitEffect.gameObject.SetActive(true);
            countdownText.transform.parent.gameObject.SetActive(false);
            countdownText.gameObject.SetActive(false);
        }
    }

    public void ShockWaveEffect()
    {
        shockWave.gameObject.SetActive(true);
        shockWave.Play();
        fireEffect.SetActive(false);
    }
}