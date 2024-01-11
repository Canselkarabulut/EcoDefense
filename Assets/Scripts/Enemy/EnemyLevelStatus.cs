using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLevelStatus : MonoBehaviour
{
    public EnemyLevel enemyLevel;
    public NavMeshAgent navMeshAgent;
 private void Start()
    {
        InitializeStart();
    }
    public EnemyLevel EnemyLevelReturn()
    {
        InitializeStart();
        return enemyLevel;
    }

    public void InitializeStart()
    {
        switch (enemyLevel)
        {
            case EnemyLevel.Lvl1Enemy:
                transform.localScale = new Vector3(1, 1, 1);
                navMeshAgent.speed = .7f;
                break;
            case EnemyLevel.Lvl2Enemy:
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                navMeshAgent.speed = .8f;
                break;
            case EnemyLevel.Lvl3Enemy:
                transform.localScale = new Vector3(2, 2, 2);
                navMeshAgent.speed = .9f;
                break;
            case EnemyLevel.Lvl4Enemy:
                transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                navMeshAgent.speed = 1f;
                break;
        }
    }
}