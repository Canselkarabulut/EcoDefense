using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public int prefabIndexToSpawn = 0;
    public Transform parentSpawnObject;

    public WaveControl waveControl;

    //  public RangeControl rangeControl;
    //  public PlayerRange playerRange;
    public GameObject pointEnemySpawn;
    public float spawnInterval = 2f;
    public float activeTimeEnemy = 3f;



    private int _childCountPointEnemy;
    private int _randomchild;
    private Transform _selectedPoint;
    private int enemySay;
    private bool isNextWave;
    private float _timer = 0f;


    private void Start()
    {
        _childCountPointEnemy = pointEnemySpawn.transform.childCount;
        // spawn için de wave lere göre sınırlanacak vawe 1 de 12 enemy gibi
    }


    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            _timer = 0f;
            SpawnObject();
        }
    }

    public void RandomSpawnPoint()
    {
        _randomchild = Random.Range(0, _childCountPointEnemy);
        _selectedPoint = pointEnemySpawn.transform.GetChild(_randomchild);
    }

    public void SpawnObject()
    {
        switch (waveControl.WaveNumberReturn())
        {
            case WaveNumber.Wave1:
                enemySay++;
                if (enemySay == waveControl.enemyLimit)
                {
                    waveControl.waveNumber = WaveNumber.Wave2;
                    waveControl.isWaveWait = true;
                }
                else
                {
                    RandomSpawnPoint();
                    GameObject obj =
                        ObjectPool.Instance.GetObjectFromPool(prefabIndexToSpawn); //hangi prefabın spawnlanacağı
                    if (obj != null && _selectedPoint != null)
                    {
                        obj.transform.SetParent(parentSpawnObject);
                        obj.transform.position = _selectedPoint.position;
                        obj.transform.rotation = _selectedPoint.rotation;
                    }
                    StartCoroutine(CheckEnemyStatus(obj)); 
                }

                break;
        }
    }

    IEnumerator CheckEnemyStatus(GameObject obj)
    {
        yield return new WaitForSeconds(activeTimeEnemy);
        ObjectPool.Instance.ReturnObjectToPool(obj);
    }
}