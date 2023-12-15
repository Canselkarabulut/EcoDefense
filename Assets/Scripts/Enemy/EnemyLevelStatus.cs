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
      if (enemyLevel == EnemyLevel.Lvl1Enemy)
      {
         transform.localScale = new Vector3(1, 1, 1);
      }
      if (enemyLevel == EnemyLevel.Lvl2Enemy)
      {
         transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
      }
      
      if (enemyLevel == EnemyLevel.Lvl3Enemy)
      {
         transform.localScale = new Vector3(2, 2, 2);
      }
      if (enemyLevel == EnemyLevel.Lvl4Enemy)
      {
         transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
      }
   }

   public EnemyLevel EnemyLevelReturn()
   {
      return enemyLevel;
   }
}
