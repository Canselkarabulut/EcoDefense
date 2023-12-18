using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public bool isTriggerPlayer;

    private void Start()
    {
        isTriggerPlayer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RangeControl rangeControl))
        {
            isTriggerPlayer = true;
            rangeControl.rangeEnemyList.Add(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out RangeControl rangeControl))
        {
            isTriggerPlayer = false;
            rangeControl.rangeEnemyList.Remove(gameObject);
        }
    }
}