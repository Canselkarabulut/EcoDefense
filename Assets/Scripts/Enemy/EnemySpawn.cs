using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public int prefabIndexToSpawn = 0;
    public Transform parentSpawnObject;
    public WaveControl waveControl;
    public GameObject pointEnemySpawn;
    public float spawnInterval = 2f;
    public TextMeshProUGUI killEnemyText;
    public int killEnemyCount;

    private int _childCountPointEnemy;
    private int _randomchild;
    private Transform _selectedPoint;
    public int enemyCount;
    private float _timer = 0f;
    public GameEconomy gameEconomy;

    private void Start()
    {
        _childCountPointEnemy = pointEnemySpawn.transform.childCount;
        enemyCount = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            if (waveControl.waitStatus == WaitStatus.Game)
            {
                _timer = 0f;
                SpawnObject();
            }
        }
    }

    public void RandomSpawnPoint()
    {
        _randomchild = Random.Range(0, _childCountPointEnemy);
        _selectedPoint = pointEnemySpawn.transform.GetChild(_randomchild);
    }

    public void SpawnObject() //düşmanı oluştur
    {
        enemyCount++; //oluşan düşmanı say

        switch (waveControl.waveNumber)
        {
            case WaveNumber.Wave1:
                spawnInterval = 2.2f;
                EnemyLevelControl(0, 1); //0
                break;
            case WaveNumber.Wave2:
                spawnInterval = 2.3f;
                EnemyLevelControl(0, 2); //0,1
                break;
            case WaveNumber.Wave3:
                spawnInterval = 2.5f;
                EnemyLevelControl(0, 2); //0,1
                break;
            case WaveNumber.Wave4:
                spawnInterval = 2.7f;
                EnemyLevelControl(0, 3); //0,1,2
                break;
            case WaveNumber.Wave5:
                spawnInterval = 3f;
                EnemyLevelControl(1, 3); //1,2
                break;
            case WaveNumber.Wave6:
                spawnInterval = 3.2f;
                EnemyLevelControl(1, 4); //1.2,3
                break;
            case WaveNumber.Wave7:
                spawnInterval = 3.7f;
                EnemyLevelControl(2, 4); //2,3
                break;
        }
    }

    public void EnemyLevelControl(int startNum, int finihNum)
    {
        if (enemyCount == waveControl.enemyLimit + 1)
        {
            waveControl.waitStatus = WaitStatus.GameBreak;
            waveControl._countdownNum = 5;
        }
        else
        {
            RandomSpawnPoint();
            GameObject obj =
                ObjectPool.Instance.GetObjectFromPool(prefabIndexToSpawn);
            if (obj != null && _selectedPoint != null)
            {
                obj.transform.SetParent(parentSpawnObject);
                obj.transform.position = _selectedPoint.position;
                obj.transform.rotation = _selectedPoint.rotation;
                //hangi lvl de üretilecek
                if (obj.GetComponent<EnemyLife>().enemyBorn.enabled)
                    obj.GetComponent<EnemyLife>().enemyBorn.enabled = true;
                // enemyLevel =obj.GetComponent<EnemyLevelStatus>().enemyLevel;
                var randomNumber = Random.Range(startNum, finihNum);
                switch (randomNumber)
                {
                    case 0:
                        obj.GetComponent<EnemyLevelStatus>().enemyLevel = EnemyLevel.Lvl1Enemy;
                        obj.GetComponent<EnemyLife>().InitializeStart();

                        break;
                    case 1:
                        obj.GetComponent<EnemyLevelStatus>().enemyLevel = EnemyLevel.Lvl2Enemy;
                        obj.GetComponent<EnemyLife>().InitializeStart();

                        break;
                    case 2:
                        obj.GetComponent<EnemyLevelStatus>().enemyLevel = EnemyLevel.Lvl3Enemy;
                        obj.GetComponent<EnemyLife>().InitializeStart();

                        break;
                    case 3:
                        obj.GetComponent<EnemyLevelStatus>().enemyLevel = EnemyLevel.Lvl4Enemy;
                        obj.GetComponent<EnemyLife>().InitializeStart();

                        break;
                }

                StartCoroutine(DieCount(obj));
            }
        }
    }


    IEnumerator DieCount(GameObject obj)
    {
        yield return new WaitUntil(() => obj.GetComponent<EnemyLife>().isDie);
        killEnemyCount++;
        killEnemyText.text = killEnemyCount.ToString();
        EnemyDieEconomy(obj);
    }

    public void EnemyDieEconomy(GameObject obj)
    {
        if (obj.GetComponent<EnemyLife>().enemyWalk.enabled)
            obj.GetComponent<EnemyLife>().enemyWalk.enabled = false;
        obj.GetComponent<EnemyLife>().enemyWalk.Stop();
        
        var enemyLevelStatus = obj.GetComponent<EnemyLevelStatus>();
        switch (enemyLevelStatus.EnemyLevelReturn())
        {
            case EnemyLevel.Lvl1Enemy:
                gameEconomy.CoinCount(10);
                break;
            case EnemyLevel.Lvl2Enemy:
                gameEconomy.CoinCount(20);
                break;
            case EnemyLevel.Lvl3Enemy:
                gameEconomy.CoinCount(30);
                break;
            case EnemyLevel.Lvl4Enemy:
                gameEconomy.CoinCount(40);
                break;
        }
    }
}