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
    public void SpawnObject()
    {
        enemyCount++;
        switch (waveControl.WaveNumberReturn())
        {
            case WaveNumber.Wave1:

                if (enemyCount == waveControl.enemyLimit)
                {
                    enemyCount = 0;
                    waveControl.waitStatus = WaitStatus.GameBreak;
                    waveControl.waveNumber = WaveNumber.Wave2 /*waveNumber*/;
                }
                else
                {
                    //waveControl.isWaveWait = false;
                    RandomSpawnPoint();
                    GameObject obj =
                        ObjectPool.Instance.GetObjectFromPool(prefabIndexToSpawn); //hangi prefabın spawnlanacağı index
                    if (obj != null && _selectedPoint != null)
                    {
                        obj.transform.SetParent(parentSpawnObject);
                        obj.transform.position = _selectedPoint.position;
                        obj.transform.rotation = _selectedPoint.rotation;
                        obj.GetComponent<EnemyLevelStatus>().enemyLevel = EnemyLevel.Lvl1Enemy;
                        StartCoroutine(DieCount(obj));
                    }
                }


                Debug.Log("enemy count: " + enemyCount);
                Debug.Log(waveControl.enemyLimit);
               
                break;
            case WaveNumber.Wave2:
                break;
            case WaveNumber.Wave3:
                break;
            case WaveNumber.Wave4:
                break;
            case WaveNumber.Wave5:
                break;
            case WaveNumber.Wave6:
                break;
            case WaveNumber.Wave7:
                break;
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