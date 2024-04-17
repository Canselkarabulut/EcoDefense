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
    private int _musicNum = 1;

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
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip musicToPlay = null;
        _musicNum = PlayerPrefs.GetInt("musicNum", 1);
        musicToPlay = backgrounMusic;
        if (_musicNum == 1)
        {
            StartMusic();
        }

        if (_musicNum == 0)
        {
            StopMusic();
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(SceneManager.GetActiveScene().buildIndex);
    }

    void PlayMusicForScene(int sceneIndex)
    {
        AudioClip musicToPlay = null;
        if (sceneIndex != 0)
        {
            if (sceneIndex % 3 == 0)
            {
                musicToPlay = actionMusic;
            }
            else
            {
                musicToPlay = backgrounMusic;
            }
        }
        else
        {
            musicToPlay = backgrounMusic;
        }

        if (musicToPlay != null)
        {
            // Müzik zaten çalıyorsa ve aynı müzik tekrar çalınacaksa
            if (audioSource.clip == musicToPlay)
            {
                // Hiçbir şey yapma
                return;
            }

            // Müziği değiştir ve çalmaya başla
            audioSource.clip = musicToPlay;
            audioSource.Play();
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