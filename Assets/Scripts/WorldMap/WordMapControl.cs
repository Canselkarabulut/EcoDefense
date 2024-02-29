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
         case 3:
            antarticaDone.SetActive(true);
            africaDone.SetActive(true);
            asiaDone.SetActive(true);
            camAnim.SetBool("isEurope",true); //isEurope
            break;
         case 4:
            antarticaDone.SetActive(true);
            africaDone.SetActive(true);
            asiaDone.SetActive(true);
            europeDone.SetActive(true);
            camAnim.SetBool("isAmerica",true); //isEurope
            break;
         case 5:
            antarticaDone.SetActive(true);
            africaDone.SetActive(true);
            asiaDone.SetActive(true);
            europeDone.SetActive(true);
            amerikaDone.SetActive(true);
            camAnim.SetBool("isOceans",true); //isEurope
            break;
         case 6:
            antarticaDone.SetActive(true);
            africaDone.SetActive(true);
            asiaDone.SetActive(true);
            europeDone.SetActive(true);
            amerikaDone.SetActive(true);
            oceanDone.SetActive(true);
            Debug.Log("GameFinish");
            //Tüm oyun bitti kısmı
            //camAnim.SetBool("isOceans",true); //isEurope
            break;
      }
   }
}
