using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject healthBar;
    public Material healthbarGreen;
    public Material healthbarOrange;
    public Material healthbarRed;
    public Animator playerAnimator;

    public GameObject ecoGun;
    public GameObject shockWave;
  //  public GameObject enemyTrigger;
    public GameObject bulletSpawn;
  public WaveControl waveControl;
    public DynamicJoystick dynamicJoystick;

    public GameObject enemys;

    private void Start()
    {
        healthBar.GetComponent<Renderer>().material = healthbarGreen;
        healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
        ecoGun.SetActive(true);
        shockWave.SetActive(true);
    //    enemyTrigger.SetActive(true);
        bulletSpawn.SetActive(true);
      waveControl.isWaveWait = false;
        dynamicJoystick.gameObject.SetActive(true);
        enemys.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyLevelStatus enemyLevelStatus))
        {
            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl1Enemy)
            {
                PlayerLossLife(0.05f);
            }
        }
    }

    public void PlayerLossLife(float amountDdeath)
    {
        
            healthBar.transform.localScale += new Vector3(-amountDdeath, 0, 0);
            if (healthBar.transform.localScale.x < .35)
            {
                healthBar.GetComponent<Renderer>().material = healthbarOrange;
                if (healthBar.transform.localScale.x < .2)
                {
                    healthBar.GetComponent<Renderer>().material = healthbarRed;
                    if (healthBar.transform.localScale.x < .05)
                    {
                        waveControl.isWaveWait = true;
                        bulletSpawn.SetActive(false);
                        healthBar.SetActive(false);
                        ecoGun.SetActive(false);
                        shockWave.SetActive(false);
                        enemys.SetActive(false);
                        playerAnimator.SetBool("isDeath", true);
                        transform.parent.GetComponent<PlayerController>().dynamicJoystick = null;
                        dynamicJoystick.gameObject.SetActive(false);
                        // enemyTrigger.SetActive(false);
                    }
                }
            }
            else
            {
                healthBar.GetComponent<Renderer>().material = healthbarGreen;
            }
        }
    
}