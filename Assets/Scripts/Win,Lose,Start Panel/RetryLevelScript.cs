using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevelScript : MonoBehaviour
{
   public WaveControl waveControl;
   private WaveNumber waveNumber;
   public void RetryButton()
   {
      waveNumber = waveControl.WaveNumberReturn();
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      waveControl.waveNumber = waveNumber;
   }
}
