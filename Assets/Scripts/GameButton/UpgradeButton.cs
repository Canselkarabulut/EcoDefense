using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    public GameObject gameUpgradePanel;
    public GameObject gameControl;

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
        Time.timeScale = 0;
    }
}
