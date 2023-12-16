using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public int prefabIndexToSpawn = 0;
    private GameObject _pointEnemySpawn;
    private int _childCountPointEnemy;
    private int _randomchild;
    private Transform _selectedPoint;
    private void Start()
    {
        _pointEnemySpawn = GameObject.Find("PointEnemySpawn");
        _childCountPointEnemy = _pointEnemySpawn.transform.childCount;
        // spawn için de wave lere göre sınırlanacak vawe 1 de 12 enemy gibi
    }
    private float _timer = 0f;
    public float spawnInterval = 2f;
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
        _selectedPoint = _pointEnemySpawn.transform.GetChild(_randomchild);
    }
   public void SpawnObject()
    {
        RandomSpawnPoint();
        GameObject obj = ObjectPool.Instance.GetObjectFromPool(prefabIndexToSpawn); //hangi prefabın spawnlanacağı

        // Spawn konumuna yerleştir
        if (obj != null && _selectedPoint != null)
        {
            obj.transform.position = _selectedPoint.position;
            obj.transform.rotation = _selectedPoint.rotation;
        }
        StartCoroutine(EnemyFalse(obj));
    }

    IEnumerator EnemyFalse( GameObject obj)
    {
        yield return new WaitForSeconds(3);
        ObjectPool.Instance.ReturnObjectToPool(obj);
    }
}
