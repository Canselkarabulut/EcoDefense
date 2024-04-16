using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOpenCount : MonoBehaviour
{
  public int gameOpenNum;

  private void Start()
  {
    gameOpenNum++;
    PlayerPrefs.SetInt("GameOpenCount",gameOpenNum);
  }
}
