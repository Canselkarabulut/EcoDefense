using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.SceneManagement;
using CrazyGames;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    public CrazyBanner bannerPrefab;
  
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

    private void Start()
    {
        CrazySDK.Init(AddBanner);
    }
    public void AddBanner() //banner yükleme
    {
        Debug.Log("banner açıldı");
        var banner = Instantiate(bannerPrefab, new Vector3(), new Quaternion(),gameObject.transform);
    }
    
    public void HideAllBanners()
    {
        // when leaving this scene in a browser build, hide all banners
        var banners = FindObjectsOfType<CrazyBanner>();
        foreach (var banner in banners)
        {
            banner.gameObject.SetActive(false);
        }

        CrazySDK.Banner.RefreshBanners();
        Debug.Log("banner gizlendi");
    }


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            HideAllBanners();

        }
    }
}