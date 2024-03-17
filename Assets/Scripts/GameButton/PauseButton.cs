using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
  public GameObject gamePausePanel;
  public GameObject gameControl;

  private void Start()
  {
    gamePausePanel.SetActive(false);
    gameControl.SetActive(true);
     Time.timeScale = 1;
  }

  public void Pause()
  {
    gameControl.SetActive(false);
    gamePausePanel.SetActive(true);
  //  if (SettingsController.isSoundNum) //sesler açıksa
  //  {
  //    firstSound = SettingsController.isSoundNum;
  //    SettingsController.isSoundNum = false;
  //  }
    Time.timeScale = 0;
  }
  
}
