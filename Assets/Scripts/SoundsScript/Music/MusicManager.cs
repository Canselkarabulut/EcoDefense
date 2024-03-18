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
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.buildIndex);
        AssignMusicButton();
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
            if (audioSource.clip == musicToPlay && audioSource.isPlaying)
            {
                // Hiçbir şey yapma
                return;
            }

            // Müziği değiştir ve çalmaya başla
            audioSource.clip = musicToPlay;
            audioSource.Play();
        }
    }

    private SettingsController settingsController;
    private Music music;
    public Button musicButton;
    void AssignMusicButton()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            settingsController= canvas.GetComponentInChildren<SettingsController>();
            if (settingsController != null)
                music = settingsController.GetComponentInChildren<Music>();
            if (music != null)
                musicButton = music.GetComponentInChildren<Button>();
            // Button musicButton = canvas.transform.Find("MusicButton").GetComponent<Button>();
            if (musicButton != null)
            {
                musicButton.onClick.RemoveAllListeners();
                musicButton.onClick.AddListener(ToggleMusic);
            }
            else
            {
                Debug.LogWarning("Music button not found on the canvas.");
            }
        }
        else
        {
            Debug.LogWarning("Canvas not found in the scene.");
        }
    }

    void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}