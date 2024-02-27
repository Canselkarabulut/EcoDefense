using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryAntarticaAnimationEvent : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator virtualCamAnimator;
    public GameObject blackTransition;

    public GameObject deadExplore;

    //  public GameObject scateboard;


    public void PlayerHopeful()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.SetBool("isPlay", true);
    }

    public void TowerShot()
    {
        if (virtualCamAnimator == null)
            return;
        virtualCamAnimator.SetBool("isTowerShot", true);
    }

    public void ScateBoardAnimStart()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.SetBool("isScatebord", true);
    }

    public void ActiveScatebord()
    {
        if (deadExplore == null)
            return;
        // scateboard.SetActive(true);
        deadExplore.SetActive(true);
        StartCoroutine(TransitionPlayer());
    }

    IEnumerator TransitionPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        blackTransition.SetActive(true);
        transform.gameObject.SetActive(false);
    }


    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public GameObject finishCapsule;

    public void FinishCapsuleSize()
    {
        if (finishCapsule == null)
            return;
        finishCapsule.SetActive(true);
    }

    public void FinishPlayerAnim()
    {
        if (playerAnimator == null)
            return;
        playerAnimator.Play("Jumping Up");
    }

    public void MapScene()
    {
        WordMapControl.mapAnimCount += 1;
        PlayerPrefs.SetInt("mapAnimCount", WordMapControl.mapAnimCount);
        SceneManager.LoadScene(1);
    }
}