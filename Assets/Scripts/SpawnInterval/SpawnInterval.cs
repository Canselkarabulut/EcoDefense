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
   private string addtxt1;
   private string addtxt2;
   private string addtxt3;
   public void AddText0()
   {
      addtxt0 = "0,";
      value.text = addtxt0;
   }
   public void AddText1()
   {
      addtxt0 = "1,";
      value.text = addtxt1;
   }
   public void AddText2()
   {
      addtxt0 = "2,";
      value.text = addtxt2;
   }
   public void AddText3()
   {
      addtxt0 = "3,";
      value.text = addtxt3;
   }
}
