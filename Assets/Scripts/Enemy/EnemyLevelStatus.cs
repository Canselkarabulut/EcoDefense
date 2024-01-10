using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class EnemyLevelStatus : MonoBehaviour
{
    public EnemyLevel enemyLevel;
 //  public GameObject belt1;
 //  public GameObject belt2;
 //  public GameObject belt3;
 //  public GameObject belt4;
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
                //     belt1.SetActive(true);
                // kuşak 1 
                break;
            case EnemyLevel.Lvl2Enemy:
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
             //   transform.localPosition += new Vector3(0, .5f, 0); 
                //       belt1.SetActive(false);
                //       belt2.SetActive(true);
                // kuşak 1 i kapat kuşak 2 aktif olsun
                break;
            case EnemyLevel.Lvl3Enemy:
                transform.localScale = new Vector3(2, 2, 2);
             //   transform.localPosition += new Vector3(0, .1f, 0); 
                //        belt2.SetActive(false);
                //       belt3.SetActive(true);
                // kuşak 2 i kapat kuşak 3 aktif olsun
                break;
            case EnemyLevel.Lvl4Enemy:
                transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
             //   transform.localPosition += new Vector3(0, 1.5f, 0); 
                //       belt3.SetActive(false);
                //        belt4.SetActive(true);
                // kuşak 3 ü kapat , kuşak 4 aktif olsun
                break;
        }
    }
}