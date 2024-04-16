using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCoinAnimator : MonoBehaviour
{
   private Animator coinAnim;

   private void Start()
   {
      coinAnim = GetComponent<Animator>();
   }

   public void CoinAnimFalse()
   {
      coinAnim.SetBool("isCoinAdd",false);
   }
}
