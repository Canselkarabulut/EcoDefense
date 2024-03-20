using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawnValue : MonoBehaviour
{
    public GameObject enemySpawnPamel;
    public void SpawnValueButton()
    {
        Time.timeScale = 0;
        enemySpawnPamel.SetActive(true);
    }
}