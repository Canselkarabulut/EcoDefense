using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
   public ParticleSystem triggerEffect;
   private void OnTriggerEnter(Collider other)
   {
      //bana değen top ise efecti patlat
      if (other.TryGetComponent(out Bullet bullet))
      {
         triggerEffect.Play();
      }
   }
}
