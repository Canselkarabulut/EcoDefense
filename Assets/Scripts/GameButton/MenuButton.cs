using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
  //bu sahneyi kapat //menü sahnesini aç

  public void Menu()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene(0);
    //menü sahnesini aç
  }
}
