using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
   public ParticleSystem triggerEffect;
   public MinusLife minusLife;
   public Animator minusLifeAnim;
   public BulletLevel triggerBulletLevel;
   public int numberLivesLost;//kaybedilen canların seviyesi

   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Bullet bullet))
      {
         triggerEffect.Play();
         triggerBulletLevel = bullet.LevelReturn();
         minusLife.gameObject.SetActive(true);
  
      }
   }

  
}
