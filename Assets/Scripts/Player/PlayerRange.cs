using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public GameObject enemys;

    private float distance;
    public float smallestDistance;
    private Transform nearestEnemy;
    public bool isEnemyNear;

    private float _lookAt;
    private EnemyMove[] enemyList;

    private void Start()
    {
        smallestDistance = Mathf.Infinity;
        isEnemyNear = false;
    }

    public GameObject NearestEnemy()
    {
        enemyList = enemys.GetComponentsInChildren<EnemyMove>();

        foreach (var enemy in enemyList)
        {
            distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemy != null)
            {
                if (distance < smallestDistance && !enemy.GetComponent<EnemyLife>().isDie)
                {
                    smallestDistance = distance;
                    nearestEnemy = enemy.transform;
                }
            }
            
        }


        return nearestEnemy.gameObject;
    }


    public bool LookAtEnemy()
    {
        _lookAt = Vector3.Distance(transform.position, NearestEnemy().transform.position);

        if (_lookAt < 3.2f)
        {
            return isEnemyNear = true;
        }
        else
        {
            return isEnemyNear = false;
        }
    }
}