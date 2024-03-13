using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordMapPlayButton : MonoBehaviour
{
    private int antarticaGameWaveCount=0;
    private int africaGameWaveCount=0;
    private int asiaGameWaveCount=0;
    private int europeGameWaveCount=0;
    private int americaGameWaveCount=0;
    private int oceanGameWaveCount=0;

    public void PlayGame()
    {
        switch (WordMapControl.mapAnimCount)
        {
            case 0:
                antarticaGameWaveCount = PlayerPrefs.GetInt("waveCount");
                if (antarticaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // antartika GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); //antartika oyun sahnesi
                }
                break;
            case 1:
                africaGameWaveCount=  PlayerPrefs.GetInt("waveCount");
                if (africaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);// afrika GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);//afrika oyun sahnesi
                }
                break;
            case 2:
                asiaGameWaveCount=  PlayerPrefs.GetInt("waveCount");
                if (asiaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);// asia GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);// asia oyun sahnesi
                }
                break;
            case 3:
                europeGameWaveCount=  PlayerPrefs.GetInt("waveCount");
                if (europeGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);// avrupa GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 11);// avrupa oyun sahnesi
                }
                break;
            case 4:
                americaGameWaveCount=  PlayerPrefs.GetInt("waveCount");
                if (americaGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 13);// amerika GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 14);// amerika oyun sahnesi
                }
                break;
            case 5:
                oceanGameWaveCount=  PlayerPrefs.GetInt("waveCount");
                if (oceanGameWaveCount <= 1)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 16);// okyanus GİRİŞ animasyonu
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 17);// okyanus oyun sahnesi
                }
                break;
            case 6:
               
               //tüm oyun bitti - play tuşu çalışmayacak onun yerine alternatif düşün
                break;
        }
    }
}