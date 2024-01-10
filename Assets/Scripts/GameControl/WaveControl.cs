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
                EnemyTextLimit("Wave 1", "12", 12);
                break;
            case WaveNumber.Wave2:
                EnemyTextLimit("Wave 2", "14", 14);
                break;
            case WaveNumber.Wave3:
                EnemyTextLimit("Wave 3", "16", 16);
                break;
            case WaveNumber.Wave4:
                EnemyTextLimit("Wave 4", "18", 18);
                break;
            case WaveNumber.Wave5:
                EnemyTextLimit("Wave 5", "20", 20);
                break;
            case WaveNumber.Wave6:
                EnemyTextLimit("Wave 6", "22", 22);
                break;
            case WaveNumber.Wave7:
                EnemyTextLimit("Wave 7", "4", 4);
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
        {//oyun arasına girdiyse
            bulletSpawn.SetActive(false);
            if (enemys.transform.childCount < 1)
            {
               
                //ve sahnedeki son kalan düşman da öldüyse 
                enemySpawn.enemyCount = 0; // ölenlerin sayısını sıfırla 

                //ateş etme spawnı kapat
                bulletSpawn.SetActive(false);
                // ateş efektini kapat
                hitEffect.gameObject.SetActive(false);
                
                //penguenleri aç
                healthPenguins.SetActive(true);
                
                //geri sayımı aç
                countdownText.gameObject.SetActive(true);
                
                
                // geri sayım parentini aç
                countdownText.transform.parent.gameObject.SetActive(true);
                
                
                if (_countdownNum <= 1)
                {
                    //geri sayım 1 in altına düştümü yani sürecini tamamladıysa 
                    //wave textlerini değiştir
                    EnemyText();
                    //ölen enemy sayı ve textlerini sıfırla 
                    enemySpawn.killEnemyCount = 0;
                    enemySpawn.killEnemyText.text = "0";
                    //yeniden oyunu game'e al
                    waitStatus = WaitStatus.Game;
                    
                    //wave yi bir sonrakine artır
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
                            waveNumber = WaveNumber.Wave7;
                            WaveNumberReturn();
                            EnemyText();
                            break;
                    }
                }
                else
                {
                    //geri sayım bitmediyse
                    _countdownNum -= Time.deltaTime;
                    //geri sayıma devam et ve texte yazdır
                    countdownText.text = Convert.ToInt32(_countdownNum).ToString();
                }
            }
        }
        else if (waitStatus == WaitStatus.Game) //oyun
        {
            //state oyun olduysa 
            bulletSpawn.SetActive(true);
            //penguenleri kapat
            healthPenguins.SetActive(false);
            //ateş etmeyi aç
            bulletSpawn.SetActive(true);
            //ateş efektini aç
            hitEffect.gameObject.SetActive(true);
            //geri sayım parentini kapat
            countdownText.transform.parent.gameObject.SetActive(false);
            //geri sayım texti kapat
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