using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    private int activeSceneIndex;
    public bool isSkipAds;
    public void StorySkip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FinishStorySkip()
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (activeSceneIndex)
        {
            case 4: //antarticaFinishStoryScene
                WordMapControl.mapAnimCount = 1;
                break;
            case 7: //africaFinishStoryScene
                WordMapControl.mapAnimCount = 2;
                break;
            case 10: //asiaFinishStoryScene
                WordMapControl.mapAnimCount = 3;
                break;
            case 13: //europeFinishStoryScene
                WordMapControl.mapAnimCount = 4;
                break;
            case 16: //americaFinishStoryScene
                WordMapControl.mapAnimCount = 5;
                break;
            case 19: //OceansFinishStoryScene
                WordMapControl.mapAnimCount = 6;
                break;
        }

        PlayerPrefs.SetInt("mapAnimCount", WordMapControl.mapAnimCount);
        isSkipAds = true;
        SceneManager.LoadScene(1);
    }
}