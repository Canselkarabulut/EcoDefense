using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Enum;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletLevel bulletLevel;
    public BulletSize bulletSize;
    public BulletRateFire bulletRateFire;
    
    private int bulletLevelNumber = 1;
    private int bulleSizeNumber = 1;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMove enemyMove))
        {
            ObjectPool.Instance.ReturnObjectToPool(gameObject);
        }
    }
}