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
  public AudioSource playerTrigger;
  public AudioSource playerDie;
  public GameObject enemys;
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
    playerTrigger.Stop();
    playerDie.Stop();
    for (int i = 0; i < enemys.transform.childCount; i++)
    {
      enemys.transform.GetChild(i).GetComponent<EnemyLife>().enemyWalk.Stop();
    }
  }
  
}
