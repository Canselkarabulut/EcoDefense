using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMapControl : MonoBehaviour
{
   public static int mapAnimCount = 0;
   public Animator camAnim;
   private void Start()
   {
      mapAnimCount = PlayerPrefs.GetInt("mapAnimCount", 0);
      switch (mapAnimCount)
      {
         case 0:
            camAnim.SetBool("isAntartica",true);
            break;
         case 1:
            camAnim.SetBool("isAfrica",true);
            break;
      }
   }
   //antartica bitti mi 
   //hayır ise antarticaya yaklaşan harita çalışsın 
   //evet ise afrikaya yaklaşan animasyon
}
