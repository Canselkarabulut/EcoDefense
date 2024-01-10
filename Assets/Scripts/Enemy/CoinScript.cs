using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private Transform _camera;
    public EnemyLevelStatus enemyLevelStatus;
    public TextMeshPro enemyPrefabCoinText;
    private void Start()
    {
        _camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
        switch (enemyLevelStatus.EnemyLevelReturn())
        {
            case EnemyLevel.Lvl1Enemy:
                enemyPrefabCoinText.text = "+10";
                break;
            case EnemyLevel.Lvl2Enemy:
                enemyPrefabCoinText.text = "+20";
                break;
            case EnemyLevel.Lvl3Enemy:
                enemyPrefabCoinText.text = "+30";
                break;
            case EnemyLevel.Lvl4Enemy:
                enemyPrefabCoinText.text = "+40";
                break;
        }
    }
}