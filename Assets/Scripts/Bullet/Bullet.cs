using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Enum;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletLevel bulletLevel;
    public BulletSize bulletSize;
    private int bulletLevelNumber = 1;
    private int bulleSizeNumber = 1;
    private void Start()
    {
        bulletLevelNumber = PlayerPrefs.GetInt("bulletLevelsNumber2");
        bulleSizeNumber = PlayerPrefs.GetInt("bulleSizeCount2");
        
        
    }

    public BulletLevel LevelReturn()
    {
        return bulletLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMove enemyMove))
        {
            ObjectPool.Instance.ReturnObjectToPool(gameObject);
        }
    }

  

    public void BulletLevelPowerButton() //upgrade silahla vurma gücü bu methodu çağıracak
    {
        bulletLevelNumber++; //tıklandığı anda 2 olacak
        switch (bulletLevelNumber)
        {
            case 1:
                bulletLevel = BulletLevel.Lvl1;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            case 2:
                bulletLevel = BulletLevel.Lvl2;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            case 3:
                bulletLevel = BulletLevel.Lvl3;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            case 4:
                bulletLevel = BulletLevel.Lvl4;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            case 5:
                bulletLevel = BulletLevel.Lvl5;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            case 6:
                bulletLevel = BulletLevel.Lvl6;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            case 7:
                bulletLevel = BulletLevel.Lvl7;
                Debug.Log("bullet lvl: " + bulletLevel);
                break;
            //boyut 7 olduktan sonra bir daha hiç bir buton açılmayacak
        }

      //bulletLevelNumber = 1;
        PlayerPrefs.SetInt("bulletLevelsNumber2", bulletLevelNumber);
     
    }


    public void BulletSizeLevelButton()
    {
        bulleSizeNumber++;//tıklandığında 2 den başlamış olacak
        switch (bulleSizeNumber)
        {
            case 1:
                bulletSize = BulletSize.Size1;
                transform.localScale = new Vector3(.4f, .4f, .4f);
                break;
            case 2:
                bulletSize = BulletSize.Size2;
                transform.localScale = new Vector3(.5f, .5f, .5f);
                break;
            case 3:
                bulletSize = BulletSize.Size3;
                transform.localScale = new Vector3(.6f, .6f, .6f);
                break;
            case 4:
                bulletSize = BulletSize.Size4;
                transform.localScale = new Vector3(.7f, .7f, .7f);
                break;
            case 5:
                bulletSize = BulletSize.Size5;
                transform.localScale = new Vector3(.8f, .8f, .8f);
                break;
            case 6:
                bulletSize = BulletSize.Size6;
                transform.localScale = new Vector3(.9f, .9f, .9f);
                break;
            case 7:
                bulletSize = BulletSize.Size7;
                transform.localScale = new Vector3(1, 1, 1);
                break;
        }

     //    bulleSizeNumber = 1;
        PlayerPrefs.SetInt("bulleSizeCount2", bulleSizeNumber);
    }
}