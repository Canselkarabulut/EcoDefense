using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public GameObject gameUpgradePanel;
    public GameObject gameControl;
    public Button pausePanel;
    private void Start()
    {
        gameUpgradePanel.SetActive(false);
        gameControl.SetActive(true);
        Time.timeScale = 1;
    }

    public void Upgrade()
    {
        gameControl.SetActive(false);
        gameUpgradePanel.SetActive(true);
        pausePanel.interactable = false;
        Time.timeScale = 0;
    }
}
