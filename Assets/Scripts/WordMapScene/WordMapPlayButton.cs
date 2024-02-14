using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordMapPlayButton : MonoBehaviour
{
    private int antarticaGameWaveCount;

    public void PlayGame()
    {
        switch (WordMapControl.mapAnimCount)
        {
            case 0:
                antarticaGameWaveCount = PlayerPrefs.GetInt("waveCount");
                if (antarticaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
                break;
            case 1:
                //afrika aniimasyon sahnesi veya direk oyun sahnesi
                break;
        }
    }
}