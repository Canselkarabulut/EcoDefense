using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinusLife : MonoBehaviour
{
    private Transform _camera;
    public EnemyLevelStatus enemyLevelStatus;
    public TextMeshPro minusLifeText;

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
                minusLifeText.text = "-2";
                break;
            case EnemyLevel.Lvl2Enemy:
                minusLifeText.text = "-4";
                break;
            case EnemyLevel.Lvl3Enemy:
                minusLifeText.text = "-6";
                break;
            case EnemyLevel.Lvl4Enemy:
                minusLifeText.text = "-8";
                break;
        }
    }
    
    public void MinusLifeClose()
    {
        transform.gameObject.SetActive(false);
    }
}
