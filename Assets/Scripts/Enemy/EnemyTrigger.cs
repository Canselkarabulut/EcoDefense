using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
   public ParticleSystem triggerEffect;
   public MinusLife minusLife;
   public Animator minusLifeAnim;
   private void OnTriggerEnter(Collider other)
   {
      //bana değen top ise efecti patlat
      if (other.TryGetComponent(out Bullet bullet))
      {
         triggerEffect.Play();
         minusLife.gameObject.SetActive(true);
         minusLifeAnim.Play("MinusLife");
         
      }
   }
}
