using System;
using Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevelScript : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}