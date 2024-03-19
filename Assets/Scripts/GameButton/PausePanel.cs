using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameObject gameControl;
    public Button upgradeButton;
    public Button pauseButton;
    public void PausePanelClose()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        if (gameObject != null)
            gameControl.SetActive(true);
        upgradeButton.interactable = true;
        pauseButton.interactable = true;
    }
}