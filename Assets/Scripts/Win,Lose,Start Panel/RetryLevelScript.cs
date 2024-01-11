using System;
using Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevelScript : MonoBehaviour
{
    public WaveControl waveControl;
    private int waveCount;
    private void Start()
    {
        waveCount = PlayerPrefs.GetInt("waveCount");
        UpdateWaveNumber();
    }
    
    public void RetryButton()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        waveCount = PlayerPrefs.GetInt("waveCount");
        UpdateWaveNumber();
        waveControl.EnemyText();
    }
    
    
    private void UpdateWaveNumber()
    {
        switch (PlayerPrefs.GetInt("waveCount"))
        {
            case 1:
                waveControl.waveNumber = WaveNumber.Wave1;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                Debug.Log("waveNumber: " + waveControl.waveNumber);
                break;
            case 2:
                waveControl.waveNumber = WaveNumber.Wave2;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                Debug.Log("waveNumber: " + waveControl.waveNumber);
                waveControl.EnemyText();
                break;
            case 3:
                waveControl.waveNumber = WaveNumber.Wave3;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                break;
            case 4:
                waveControl.waveNumber = WaveNumber.Wave4;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                break;
            case 5:
                waveControl.waveNumber = WaveNumber.Wave5;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                break;
            case 6:
                waveControl.waveNumber = WaveNumber.Wave6;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                break;
            case 7:
                waveControl.waveNumber = WaveNumber.Wave7;
                Debug.Log("retry: "+ PlayerPrefs.GetInt("waveCount"));
                break;
        }
    }
}