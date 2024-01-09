using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public GameObject losePanel;

    private void Start()
    {
        losePanel.SetActive(false);
    }

    public void LosePanel()
    {
        losePanel.SetActive(true);
    }
}
