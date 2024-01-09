using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevelScript : MonoBehaviour
{

   public void RetryButton()
   {
      string sceneName = SceneManager.GetActiveScene().name;
      //Sahneyi yeniden yükleyin
      SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
