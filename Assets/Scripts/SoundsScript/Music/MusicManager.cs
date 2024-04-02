using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgrounMusic;
    public AudioClip actionMusic;

    [HideInInspector] public AudioSource audioSource;

    private static MusicManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayMusicForScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("musicNum") == 0)
        {
            StopMusic();
        }

        if (PlayerPrefs.GetInt("musicNum") == 1)
        {
            StartMusic();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.buildIndex);
    }
    void PlayMusicForScene(int sceneIndex)
    {
        AudioClip musicToPlay = null;

        switch (sceneIndex)
        {
            case 0:
                musicToPlay = backgrounMusic;
                break;
            case 3:
                musicToPlay = actionMusic;
                break;
            case 4:
                musicToPlay = backgrounMusic;
                break;
            case 6:
                musicToPlay = actionMusic;
                break;
            case 7:
                musicToPlay = backgrounMusic;
                break;
            case 9:
                musicToPlay = actionMusic;
                break;
            case 10:
                musicToPlay = backgrounMusic;
                break;
            case 12:
                musicToPlay = actionMusic;
                break;
            case 13:
                musicToPlay = backgrounMusic;
                break;
            case 15:
                musicToPlay = actionMusic;
                break;
            case 16:
                musicToPlay = backgrounMusic;
                break;
            case 18:
                musicToPlay = actionMusic;
                break;
            case 19:
                musicToPlay = backgrounMusic;
                break;
            default:
                musicToPlay = backgrounMusic;
                break;
        }

        if (musicToPlay != null)
        {
            // Müzik zaten çalıyorsa ve aynı müzik tekrar çalınacaksa
            if (audioSource.clip == musicToPlay || audioSource.isPlaying)
            {
                // Hiçbir şey yapma
                return;
            }

            // Müziği değiştir ve çalmaya başla
            audioSource.clip = musicToPlay;
            if (PlayerPrefs.GetInt("musicNum") == 1)
            {
                StartMusic();
            } else if (PlayerPrefs.GetInt("musicNum") == 0)
            {
                StopMusic();
            }
           
        }
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void StartMusic()
    {
        audioSource.Play();
    }
}