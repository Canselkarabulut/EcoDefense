using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private EnemyLevelStatus _enemyLevelStatus;
    private int _lifeCapacity;

    private void Awake()
    {
        _enemyLevelStatus = this.gameObject.GetComponent<EnemyLevelStatus>();
    }

    private void Start()
    {
       
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl1Enemy)
        {
            _lifeCapacity = 4;
        }
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl2Enemy)
        {
            _lifeCapacity = 6;
        }
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl3Enemy)
        {
            _lifeCapacity = 8;
        }
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl4Enemy)
        {
            _lifeCapacity = 10;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // bana değen mermi ise say arta arta;
        //mermi sayısı == lafecapasity ise ;
        //evet ise
        // beni yok et
        // para hanesine + 10 puan yazılsın
        // hayır ise
        //kafaının üzerinde  text ile - yazacak örn: -2 ;
    }
}
