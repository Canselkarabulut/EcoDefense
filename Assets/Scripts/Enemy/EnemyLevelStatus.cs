using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class EnemyLevelStatus : MonoBehaviour
{
    public EnemyLevel enemyLevel;

    private void Start()
    {
        switch (enemyLevel)
        {
            case EnemyLevel.Lvl1Enemy:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case EnemyLevel.Lvl2Enemy:
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                break;
            case EnemyLevel.Lvl3Enemy:
                transform.localScale = new Vector3(2, 2, 2);
                break;
            case EnemyLevel.Lvl4Enemy:
                transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
        }
    }

    public EnemyLevel EnemyLevelReturn()
    {
        return enemyLevel;
    }
}