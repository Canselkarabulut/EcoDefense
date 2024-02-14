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
        playerAnimator.SetBool("isPlay", true);
    }

    public void TowerShot()
    {
        virtualCamAnimator.SetBool("isTowerShot", true);
    }

    public void ScateBoardAnimStart()
    {
        playerAnimator.SetBool("isScatebord", true);
    }

    public void ActiveScatebord()
    {
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
        finishCapsule.SetActive(true);
    }

    public void FinishPlayerAnim()
    {
        playerAnimator.Play("JumpingUp");
    }

    public void MapScene()
    {
        WordMapControl.mapAnimCount = 1;
        PlayerPrefs.SetInt("mapAnimCount", WordMapControl.mapAnimCount);
        SceneManager.LoadScene(1);
    }
    
   
    
}