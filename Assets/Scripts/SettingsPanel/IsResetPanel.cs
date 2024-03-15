using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsResetPanel : MonoBehaviour
{
    public GameObject resetPanel;
    public void ResetPanelOpen()
    {
        resetPanel.SetActive(true);
    }
}
