using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
public class PlayerTrigger : MonoBehaviour
{
    public GameObject healthBar;
    public Material healthbarGreen;
    public Material healthbarOrange;
    public Material healthbarRed;
    public Animator playerAnimator;

    public GameObject ecoGun;
    public GameObject shockWave;
    public GameObject bulletSpawn;
    public DynamicJoystick dynamicJoystick;

    public GameObject enemys;

    public ParticleSystem loseEffect;
    public GameObject dieEffect;

    private void Start()
    {
        DOTween.Init();
        healthBar.GetComponent<Renderer>().material = healthbarGreen;
        healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
        ecoGun.SetActive(true);
        shockWave.SetActive(true);
     //   bulletSpawn.SetActive(true);
        dynamicJoystick.gameObject.SetActive(true);
        enemys.SetActive(true);
        dieEffect.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyLevelStatus enemyLevelStatus))
        {
            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl1Enemy)
            {
                PlayerLossLife(0.02f);
            }
            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl2Enemy)
            {
                PlayerLossLife(0.04f);
            }
            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl3Enemy)
            {
                PlayerLossLife(.06f);
            }
            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl4Enemy)
            {
                PlayerLossLife(0.08f);
            }
        }
    }
    
    public void PlayerLossLife(float amountDdeath)
    {
        
            healthBar.transform.localScale += new Vector3(-amountDdeath, 0, 0);
            loseEffect.Play();
        
            if (healthBar.transform.localScale.x < .35)
            {
                healthBar.GetComponent<Renderer>().material = healthbarOrange;
                if (healthBar.transform.localScale.x < .2)
                {
                    healthBar.GetComponent<Renderer>().material = healthbarRed;
                    if (healthBar.transform.localScale.x < .05)
                    {
                        dieEffect.SetActive(true);
                        bulletSpawn.SetActive(false);
                        healthBar.SetActive(false);
                        ecoGun.SetActive(false);
                        shockWave.SetActive(false);
                        enemys.SetActive(false);
                        playerAnimator.SetBool("isDeath", true);
                        transform.parent.GetComponent<PlayerController>().dynamicJoystick = null;
                        dynamicJoystick.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                healthBar.GetComponent<Renderer>().material = healthbarGreen;
            }
        }
    
}