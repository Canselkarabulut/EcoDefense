using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public GameObject enemys;

//ekranda aktif olan tüm enemyleri listele
//listede bana en yakın olanı bul

//enemys çocuklarını dolan sürekli mesfelerini hesapla en yakını bul
    public float distance;
    private float _smallestDistance;
    public Transform nearestEnemy;
    private EnemyMove[] enemyList;
   // public GameObject closesDetermined;
    public bool isEnemyNear;
    private void Start()
    {
        _smallestDistance = Mathf.Infinity;
        isEnemyNear = false;
    }
    private void Update()
    {
        if (enemys.transform.childCount > 0)
        {
          //  NearestEnemy();
        }
    }

    public GameObject NearestEnemy()
    {
        enemyList = enemys.GetComponentsInChildren<EnemyMove>();
        
        foreach (var enemy in enemyList)
        {
            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < _smallestDistance)
            {
                _smallestDistance = distance;
                nearestEnemy = enemy.transform;
            }
            
        }
        return nearestEnemy.gameObject;
    }

    private float lookAt;
    public bool LookAtEnemy()
    {
        lookAt = Vector3.Distance(transform.position, NearestEnemy().transform.position);
        
        if (lookAt < 2.7f)
        {
            return  isEnemyNear = true;
        }
        else
        {
         return   isEnemyNear = false;
        }
    }
}