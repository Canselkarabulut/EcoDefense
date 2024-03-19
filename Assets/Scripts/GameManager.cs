using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance { get; set; }

    private void Awake()
    {
        SingletonThidGameManager();
    }


    void SingletonThidGameManager()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}