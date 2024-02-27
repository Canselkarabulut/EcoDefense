using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordMapPlayButton : MonoBehaviour
{
    private int antarticaGameWaveCount=0;
    private int africaGameWaveCount=0;

    public void PlayGame()
    {
        switch (WordMapControl.mapAnimCount)
        {
            case 0:
                antarticaGameWaveCount = PlayerPrefs.GetInt("waveCount");
                if (antarticaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // oyun sahnesi
                }
                break;
            case 1:
                africaGameWaveCount=  PlayerPrefs.GetInt("waveCount");
                if (africaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
                }
                break;
        }
    }
}