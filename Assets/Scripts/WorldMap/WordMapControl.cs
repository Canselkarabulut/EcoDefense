using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordMapControl : MonoBehaviour
{
   public static int mapAnimCount;
   public Animator camAnim;
   public GameObject antarticaDone;
   public GameObject africaDone;
   public GameObject asiaDone;
   public GameObject europeDone;
   public GameObject amerikaDone;
   public GameObject oceanDone;
   private void Start()
   {
      mapAnimCount = PlayerPrefs.GetInt("mapAnimCount",0);
      switch (mapAnimCount)
      {
         case 0:
            camAnim.SetBool("isAntartica",true);
            break;
         case 1:
            antarticaDone.SetActive(true);
            camAnim.SetBool("isAfrica",true);
            break;
         case 2:
            antarticaDone.SetActive(true);
            africaDone.SetActive(true);
            camAnim.SetBool("isAsia",true);
            break;
      }
   }
}
