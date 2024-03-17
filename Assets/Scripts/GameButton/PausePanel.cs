using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject gameControl;
    
    public void PausePanelClose()
    {
        Time.timeScale = 1;
      //  SettingsController.isSoundNum = PauseButton.firstSound;
        gameObject.SetActive(false);
        gameControl.SetActive(true);
       
    }
    
}
