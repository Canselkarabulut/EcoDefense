using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Enum;
using UnityEngine;

public class HeartControl : MonoBehaviour
{
    public GameObject gameControl;
    public WaveControl waveControl;
    public GameObject enemys;

    private void Start()
    {
        gameControl = GameObject.Find("GameControls");
        waveControl = gameControl.GetComponent<WaveControl>();
        enemys = GameObject.Find("Enemys");
    }

    public void Update()
    {
        if (waveControl.waitStatus == WaitStatus.GameBreak)
        {
            if (enemys.GetComponentsInChildren<EnemyMove>().Length <1)
            {
                gameObject.SetActive(false);
            }
           
        }
    }
}