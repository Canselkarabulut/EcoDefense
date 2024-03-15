using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNoScript : MonoBehaviour
{
   public GameObject isResetPanel; // reset panel sorgusunu kapat
   public GameObject pausePanel; //pause paneli kapat
   public GameObject gameControl;
   public void NoButton()
   {
      Time.timeScale = 1;
      isResetPanel.SetActive(false);
      pausePanel.SetActive(false);
      gameControl.SetActive(true);
   }
}
