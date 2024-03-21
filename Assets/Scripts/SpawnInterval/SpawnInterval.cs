using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnInterval : MonoBehaviour
{
   public float spawnInterval;
   public EnemySpawn enemySpawn;
   public TMP_InputField value;
   private float valueText;
   public TextMeshProUGUI updateValue;
   public GameObject spawnIntervalPanel;
   private void Start()
   {
      updateValue.text = enemySpawn.spawnInterval.ToString();
   }

   public void SpawnIntervalControl()
   { 
      valueText = Convert.ToSingle(value.text);
      enemySpawn.spawnInterval = valueText;
      updateValue.text = enemySpawn.spawnInterval.ToString();
   }

   public void CloseButton()
   {
      Time.timeScale = 1;
      spawnIntervalPanel.SetActive(false);
   }

   private string addtxt0;
   public void AddText0()
   {
      addtxt0 = "0,";
      value.text = addtxt0;
   }
}
