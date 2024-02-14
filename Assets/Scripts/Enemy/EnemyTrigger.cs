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
         //burada güncelleyebilirsem değdiği anda kontrol
         triggerBulletLevel = bullet.bulletLevel; //bana değen bulletin leveline bak ve onu tut
         minusLife.gameObject.SetActive(true);
  
      }
   }
}
