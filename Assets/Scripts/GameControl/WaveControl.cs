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
    [Header("Enum")] public WaveNumber waveNumber;
    public WaitStatus waitStatus;

    [Header("CountDown")] public float _countdownNum ;
    public TextMeshProUGUI countdownText;
    private bool isCountdown = false;

    [Header("Canvas")] public TextMeshProUGUI waveText;
    public TextMeshProUGUI totalEnemyText;
    public GameObject upgradeButton;
    public UpgradeButtonScript upgradePanel;
    public GameObject floatingJoystick;

    [Header("GameObject")] public GameObject enemys;
    public GameObject bulletSpawn;
    public ParticleSystem shockWave;
    public GameObject hitEffect;
    public GameObject healthPenguins;
    public EnemySpawn enemySpawn;
    public GameObject fireEffect;
    public GameObject enemyTextBG;
    public GameObject player;
    public Transform sceneCenter;
    public GameObject ecoGun;
    [HideInInspector] public int enemyLimit;
    private float _timer;

    [Header("EnemyCount")] public int wave1EnemyLimit = 12;
    public int wave2EnemyLimit = 14;
    public int wave3EnemyLimit = 16;
    public int wave4EnemyLimit = 18;
    public int wave5EnemyLimit = 20;
    public int wave6EnemyLimit = 22;
    public int wave7EnemyLimit = 25;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("waveCount"))
        {
            case 1:
                waveNumber = WaveNumber.Wave1;
                upgradePanel.LoadPlayerPrefs();
                break;
            case 2:
                waveNumber = WaveNumber.Wave2;
                upgradePanel.LoadPlayerPrefs();
                break;
            case 3:
                waveNumber = WaveNumber.Wave3;
                upgradePanel.LoadPlayerPrefs();
                break;
            case 4:
                waveNumber = WaveNumber.Wave4;
                upgradePanel.LoadPlayerPrefs();
                break;
            case 5:
                waveNumber = WaveNumber.Wave5;
                upgradePanel.LoadPlayerPrefs();
                break;
            case 6:
                waveNumber = WaveNumber.Wave6;
                upgradePanel.LoadPlayerPrefs();
                break;
            case 7:
                waveNumber = WaveNumber.Wave7;
                upgradePanel.LoadPlayerPrefs();
                break;
        }

        EnemyText();
        waitStatus = WaitStatus.Game;
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
                EnemyTextLimit("Wave 1 / 7", wave1EnemyLimit.ToString(), wave1EnemyLimit, 1);
                break;
            case WaveNumber.Wave2:
                EnemyTextLimit("Wave 2 / 7", wave2EnemyLimit.ToString(), wave2EnemyLimit, 2);
                break;
            case WaveNumber.Wave3:
                EnemyTextLimit("Wave 3 / 7", wave3EnemyLimit.ToString(), wave3EnemyLimit, 3);
                break;
            case WaveNumber.Wave4:
                EnemyTextLimit("Wave 4 / 7", wave4EnemyLimit.ToString(), wave4EnemyLimit, 4);
                break;
            case WaveNumber.Wave5:
                EnemyTextLimit("Wave 5 / 7", wave5EnemyLimit.ToString(), wave5EnemyLimit, 5);
                break;
            case WaveNumber.Wave6:
                EnemyTextLimit("Wave 6 / 7", wave6EnemyLimit.ToString(), wave6EnemyLimit, 6);
                break;
            case WaveNumber.Wave7:
                EnemyTextLimit("Wave 7 / 7", wave7EnemyLimit.ToString(), wave7EnemyLimit, 7);
                break;
        }
    }

    private void EnemyTextLimit(string _waveString, string _totalEnemyText, int _enemyLimit, int waveCount)
    {
        PlayerPrefs.SetInt("waveCount", waveCount);
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
                if (_countdownNum > 1)
                {
                    isCountdown = true;
                }

                if (!isCountdown)
                {
                    EnemyText();
                    enemySpawn.killEnemyCount = 0;
                    enemySpawn.killEnemyText.text = "0";
                    PlayerPrefs.SetInt("CountCoin6", GameEconomy.sCoinCount); // bölüm bittikçe parayı kaydet
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
                            //oyun tamamlandı

                            waveText.text = "Next";
                            enemySpawn.gameObject.SetActive(false);
                            enemyTextBG.SetActive(false);
                            player.transform.position = sceneCenter.position;
                            player.transform.rotation = Quaternion.Euler(0, 180, 0);
                            player.GetComponent<PlayerController>().floatingJoystick = null;
                            floatingJoystick.gameObject.SetActive(false);
                            ecoGun.SetActive(false); // silahı kapat
                            player.GetComponent<Animator>().SetBool("isWinDance", true);

                            PlayerPrefs.SetInt("waveCount", 1);
                            break;
                    }

                    WaveWaitTime();
                }
            }
            else
            {
                StartCoroutine(EnemysZeroWait());
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
            StartCoroutine(GameBreakWait());
        }
    }

    IEnumerator GameBreakWait()
    {
        yield return new WaitUntil(() => waitStatus == WaitStatus.GameBreak);
        WaveWaitTime();
    }

    IEnumerator EnemysZeroWait()
    {
        yield return new WaitUntil(() => enemys.transform.childCount < 1);
        WaveWaitTime();
    }

    public void FixedUpdate()
    {
        if (isCountdown)
        {
            _countdownNum -= Time.deltaTime;
            countdownText.text = Convert.ToInt32(_countdownNum).ToString();
            if (_countdownNum <= 1)
            {
                isCountdown = false;
                WaveWaitTime();
            }
        }
    }

    public void ShockWaveEffect()
    {
        shockWave.gameObject.SetActive(true);
        shockWave.Play();
        fireEffect.SetActive(false);
    }
}