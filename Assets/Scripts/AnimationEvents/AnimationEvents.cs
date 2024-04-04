using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject elementalArrow;
    public Animator playerAnimator;
    private void Start()
    {
        losePanel.SetActive(false);
    }

    public bool isLoseAds;
    public void LosePanel()
    {
        isLoseAds = true;
        losePanel.SetActive(true);
    }

    public void ActiveScateboard()
    {
        playerAnimator.Play("Skateboarding");  
    }

    public void TransitionAnim()
    {
        elementalArrow.SetActive(true);
        StartCoroutine(TransitionAnimWait());
    }

    IEnumerator TransitionAnimWait()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}