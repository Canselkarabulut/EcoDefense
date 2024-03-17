using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
  public GameObject gamePausePanel;
  public GameObject gameControl;
  
  [Header("Audio")] public AudioSource camAudio;
  public AudioSource playerAudio;
  public AudioSource fireAudio;
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
    Time.timeScale = 0;
    camAudio.Stop();
    playerAudio.Stop();
    fireAudio.Stop();
  }
  
}
