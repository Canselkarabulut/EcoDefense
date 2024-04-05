using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

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
    public FloatingJoystick floatingJoystick;

    public GameObject enemys;

    public ParticleSystem loseEffect;
    public GameObject dieEffect;
    public TextMeshPro minusLifeText;

    public bool isDie;
    public static bool isHealthRed;

    public GameObject showRewardedAdsButton;

//    public GameObject PauseButton;

    public SettingsController settingsController;

    private void Start()
    {
        DOTween.Init();
        healthBar.GetComponent<Renderer>().material = healthbarGreen;
        healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
        ecoGun.SetActive(true);
        shockWave.SetActive(true);
        //   bulletSpawn.SetActive(true);
        floatingJoystick.gameObject.SetActive(true);
        enemys.SetActive(true);
        dieEffect.SetActive(false);
        isDie = false;
        //   PauseButton.SetActive(true);
        showRewardedAdsButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyLevelStatus enemyLevelStatus))
        {
            minusLifeText.gameObject.SetActive(true);
            settingsController.playerTrigger.Play();
            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl1Enemy)
            {
                PlayerLossLife(0.02f);
                minusLifeText.text = "-2";
            }

            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl2Enemy)
            {
                PlayerLossLife(0.04f);
                minusLifeText.text = "-4";
            }

            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl3Enemy)
            {
                PlayerLossLife(.06f);
                minusLifeText.text = "-6";
            }

            if (enemyLevelStatus.enemyLevel == EnemyLevel.Lvl4Enemy)
            {
                PlayerLossLife(0.08f);
                minusLifeText.text = "-5";
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
                showRewardedAdsButton.SetActive(true);
                if (healthBar.transform.localScale.x < .05)
                {
                    //   bulletSpawn.SetActive(false);
                    isDie = true;
                    dieEffect.SetActive(true);
                    healthBar.SetActive(false);
                    ecoGun.SetActive(false);
                    shockWave.SetActive(false);
                    enemys.SetActive(false);
                    playerAnimator.SetBool("isDeath", true);
                    settingsController.playerDie.Play();
                    transform.parent.GetComponent<PlayerController>().floatingJoystick = null;
                    floatingJoystick.gameObject.SetActive(false);
                    showRewardedAdsButton.SetActive(false);
                    //  PauseButton.SetActive(false);
                }
            }
        }
        else
        {
            healthBar.GetComponent<Renderer>().material = healthbarGreen;
        }
    }

    private void Update()
    {
        if (showRewardedAdsButton.activeInHierarchy)
        {
            if (healthBar.transform.localScale.x > .2)
            {
                showRewardedAdsButton.SetActive(false);
                Debug.Log("can buton kalksın");
            }
        }
    }
}