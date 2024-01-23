using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinusLife : MonoBehaviour
{
    private Transform _camera;
    public EnemyLevelStatus enemyLevelStatus;
    public TextMeshPro minusLifeText;
    public EnemyTrigger enemyTrigger;
  //  public bool isMinusLifeText;

    private void Start()
    {
        _camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
     //   MinusText();
    }

    public void MinusText()
    {
        switch (enemyLevelStatus.EnemyLevelReturn())
        {
            case EnemyLevel.Lvl1Enemy:
                MinusBulletLevel("-2","-3","-4","-5","-6","-7","-8");
                break;
            case EnemyLevel.Lvl2Enemy:
                MinusBulletLevel("-4","-5","-6","-7","-8","-9","-10");
                break;
            case EnemyLevel.Lvl3Enemy:
                MinusBulletLevel("-6","-7","-8","-9","-10","-11","-12");
                break;
            case EnemyLevel.Lvl4Enemy:
                MinusBulletLevel("-8","-9","-10","-11","-12","-13","-14");
                break;
        }
    }

    public void MinusBulletLevel(string lvl1,string lvl2,string lvl3,string lvl4,string lvl5,string lvl6,string lvl7)
    {
        switch (enemyTrigger.triggerBulletLevel)
        {
            case BulletLevel.Lvl1:
                minusLifeText.text = lvl1;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl1);
                break;
            case BulletLevel.Lvl2:
                minusLifeText.text = lvl2;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl2);
                break;
            case BulletLevel.Lvl3:
                minusLifeText.text = lvl3;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl3);
                break;
            case BulletLevel.Lvl4:
                minusLifeText.text = lvl4;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl4);
                break;
            case BulletLevel.Lvl5:
                minusLifeText.text = lvl5;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl5);
                break;
            case BulletLevel.Lvl6:
                minusLifeText.text = lvl6;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl6);
                break;
            case BulletLevel.Lvl7:
                minusLifeText.text = lvl7;
                enemyTrigger.numberLivesLost = System.Convert.ToInt32(lvl7);
                break;
        }
    }
    public void MinusLifeClose()
    {
        transform.gameObject.SetActive(false);
    }
}
