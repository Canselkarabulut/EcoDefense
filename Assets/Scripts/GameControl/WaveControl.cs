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
    [HideInInspector] public bool isWaveWait = false;
    public TextMeshProUGUI countdownText;
    public GameObject enemys;
    public GameObject bulletSpawn;
    public ParticleSystem shockWave;
    public GameObject hitEffect;
    public GameObject healthPenguins;
    public EnemySpawn enemySpawn;
    public GameObject fireEffect;

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
                EnemyTextLimit("12", 13);
                break;
            case WaveNumber.Wave2:
                EnemyTextLimit("14", 15);
                break;
            case WaveNumber.Wave3:
                EnemyTextLimit("16", 17);
                break;
            case WaveNumber.Wave4:
                EnemyTextLimit("18", 19);
                break;
            case WaveNumber.Wave5:
                EnemyTextLimit("20", 21);
                break;
            case WaveNumber.Wave6:
                EnemyTextLimit("22", 23);
                break;
            case WaveNumber.Wave7:
                EnemyTextLimit("4", 5);
                break;
        }
    }

    private void EnemyTextLimit(string _totalEnemyText, int _enemyLimit)
    {
        totalEnemyText.text = _totalEnemyText;
        enemyLimit = _enemyLimit;
        ShockWaveEffect();
    }

    public void WaveWaitTime()
    {
        if (isWaveWait)
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
                    isWaveWait = false;
                }
                else
                {
                    _countdownNum -= Time.deltaTime;
                    countdownText.text = Convert.ToInt32(_countdownNum).ToString();
                }
            }
        }
        else
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