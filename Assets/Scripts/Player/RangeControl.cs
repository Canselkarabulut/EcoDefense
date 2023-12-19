using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeControl : MonoBehaviour
{
     public List<GameObject> rangeEnemyList;
     private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyTrigger enemyTrigger))
        {
            rangeEnemyList.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyTrigger enemyTrigger))
        {
            rangeEnemyList.Remove(other.gameObject);
        }
    }
}