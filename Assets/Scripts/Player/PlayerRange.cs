using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public GameObject enemys;

    public float distance;
    public float smallestDistance;
    public Transform nearestEnemy;
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
                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    nearestEnemy = enemy.transform;
                }
            }
            return nearestEnemy.gameObject;
    }


    public bool LookAtEnemy()
    {
            _lookAt = Vector3.Distance(transform.position, NearestEnemy().transform.position);

            if (_lookAt < 2.7f)
            {
                return isEnemyNear = true;
            }
            else
            {
                return isEnemyNear = false;
            }
    }
}