using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class BannerAds : MonoBehaviour
{
    [Header("Control")] private MusicManager musicManager;
    public SettingsController settingsController;
    public WaveControl waveControl;
    public GameEconomy gameEconomy;

    public PlayerTrigger playerTrigger;

    // public AnimationEvents bodyAnimationEvents;

    [Header("Button")] public GameObject showRewardedAdsButton;
    public GameObject additionalMoneyButton;

//    public TextMeshProUGUI additionalMoneyCountText;

    //public GameObject tutorialFirstAdsPanel;
    public Button upgradeButton;

    public Animator coinAnim;


    public TextMeshProUGUI adsTestTxt;
    public TextMeshProUGUI adsTestTxt2;
    public TextMeshProUGUI adsTestTxt3;
    public TextMeshProUGUI adsTestTxt4;


    [Header("Music")] private int lastMusicNum;
    private int lastSoundNum;


    [Header("Text")] public int additionalMoneyCount = 2;
//    public TextMeshProUGUI additionalMoneyCountText;

    //public GameObject tutorialFirstAdsPanel;


    public bool isAdsShownRewardedHealth = false;
    public bool isAdsShownRewarded = false;


    public int countShowRewardedClick;
    public bool idLoadRewardedAd;

    private int sceneIndex;

    private void Start()
    {
        //  Device ID: 8c1ddbefce0a2013f39016529e5cd145
        Debug.Log("Device ID: " + SystemInfo.deviceUniqueIdentifier);

        sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        adsTestTxt.text = "scene " + sceneIndex + "  hola";
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) => { });
        LoadAd();
        LoadInterstitialAd(); // geçiş reklamı
        LoadRewardedAdHealth(); //ödüllü reklam CAN
        LoadRewardedAdditionalMoney(); // ÖDÜLLÜ REKLAM EKRA PARA
        musicManager = FindObjectOfType<MusicManager>();
        lastMusicNum = PlayerPrefs.GetInt("musicNum");
        lastSoundNum = PlayerPrefs.GetInt("soundNum");
        isAdsShownRewardedHealth = false;
        isAdsShownRewarded = false;
    }

   
    // private void Update()
    // {
    //     // geçiş reklamını yakalamak için
//
    //     if (waveControl != null)
    //     {
    //         if (waveControl.isAds)
    //         {
    //             ShowInterstitialAd();
    //             waveControl.isAds = false;
    //         }
    //     }
    // }

    #region Banner

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
     private string _adUnitId = "ca-app-pub-6768650963516253/7128626846"; //orjinal
 //   private string _adUnitId = "ca-app-pub-3940256099942544/6300978111"; //test
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

    BannerView _bannerView;

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void CreateBannerView()
    {
        ///// Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // Create a 320x50 banner at top of the screen

        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
    }


    public void LoadAd()
    {
        // create an instance of a banner view first.
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        Debug.Log("Loading banner ad.");
        //  if (adsTestTxt != null)
        //  {
        //      adsTestTxt.text = "Loading banner ad.";
        //  }
        ListenToAdEvents(); // <-- EKLENMESİ GEREKİYOR

        _bannerView.LoadAd(adRequest);
    }

    /// <summary>
    /// listen to events the banner view may raise.
    /// </summary>
    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                      + _bannerView.GetResponseInfo());
            //   adsTestTxt.text = "Banner view loaded an ad with response : ";
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                           + error);
            //    adsTestTxt.text = "Banner view failed to load an ad with error : "
            //                      + error;
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
            //  adsTestTxt.text = String.Format("Banner view paid {0} {1}.",
            //      adValue.Value,
            //      adValue.CurrencyCode);
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
            //  adsTestTxt.text = "Banner view recorded an impression.";
        };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
            //    adsTestTxt.text = "Banner view was clicked.";
        };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
            //   adsTestTxt.text = "Banner view full screen content opened.";
        };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
            //     adsTestTxt.text = "Banner view full screen content closed.";
        };
    }

    /// <summary>
    /// Destroys the banner view.
    /// </summary>
    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            Debug.Log("Destroying banner view.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    #endregion

    #region InterstitialAd

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
     private string _adInterstitialUnitId = "ca-app-pub-6768650963516253/3341107840"; //orjinal
  //  private string _adInterstitialUnitId = "ca-app-pub-3940256099942544/1033173712"; //test

#elif UNITY_IPHONE
  private string _adInterstitialUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adInterstitialUnitId = "unused";
#endif
    private InterstitialAd _interstitialAd;

    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

/////        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_adInterstitialUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

/////                Debug.Log("Interstitial ad loaded with response : "
/////                          + ad.GetResponseInfo());
                ///
                if (adsTestTxt2 != null)
                {
                    adsTestTxt2.text = "_ad = _interstitialAd";
                }

                Debug.Log("_ad = _interstitialAd");
                _interstitialAd = ad;
                RegisterEventHandlers(_interstitialAd);
            });
    }

    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            /////           Debug.Log("Showing interstitial ad.");
            //sesleri kapat
            if (musicManager != null)
            {
                lastMusicNum = PlayerPrefs.GetInt("musicNum");
                musicManager.StopMusic();
            }

            if (settingsController != null)
            {
                lastSoundNum = PlayerPrefs.GetInt("soundNum");
                settingsController.GameSoundState(false, false, false, false, false, false, false, false,
                    false);
            }

            _interstitialAd.Show();
            RegisterReloadHandler(_interstitialAd);
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            /*"Interstitial ad recorded an impression.");*/
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () => { Debug.Log("Interstitial ad was clicked."); };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    private void RegisterReloadHandler(InterstitialAd interstitialAd)
    {
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            /////           Debug.Log("Interstitial Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
            //sesleri eski haline çevir
            if (musicManager != null)
            {
                if (lastMusicNum == 1)
                {
                    musicManager.StartMusic();
                }
            }

            if (settingsController != null)
            {
                if (lastSoundNum == 1)
                {
                    settingsController.GameSoundState(true, true, true, true, true, true, true, true, true);
                }
            }
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
    }

    #endregion

    #region RewardedAd

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
      private string _adRewardedUnitId = "ca-app-pub-6768650963516253/9654987332"; //orjinal
  //  private string _adRewardedUnitId = "ca-app-pub-3940256099942544/5224354917"; //test
#elif UNITY_IPHONE
  private string _adRewardedUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
  private string _adRewardedUnitId = "unused";
#endif

    private RewardedAd _rewardedAdAdHealth;
    private RewardedAd _rewardedAdAdsAdditionalMoney;

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAdHealth()
    {
        isAdsShownRewarded = false;
        // Clean up the old ad before loading a new one.
        if (_rewardedAdAdHealth != null)
        {
            _rewardedAdAdHealth.Destroy();
            _rewardedAdAdHealth = null;
        }

/////        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adRewardedUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

/////                Debug.Log("Rewarded ad loaded with response : "
/////                          + ad.GetResponseInfo());

                _rewardedAdAdHealth = ad;
                if (adsTestTxt3 != null)
                {
                    adsTestTxt3.text = "_ad = rewardedAd Health";
                }

                Debug.Log("_ad = rewardedAd");
                HealthRegisterEventHandlers(_rewardedAdAdHealth);
            });
    }

    public void ShowRewardedAdHealth()
    {
        countShowRewardedClick++;
        if (countShowRewardedClick == 2)
        {
            const string rewardMsg =
                "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

            if (_rewardedAdAdHealth != null && _rewardedAdAdHealth.CanShowAd())
            {
                //sesleri kapat
                if (musicManager != null)
                {
                    lastMusicNum = PlayerPrefs.GetInt("musicNum");
                    musicManager.StopMusic();
                }

                if (settingsController != null)
                {
                    lastSoundNum = PlayerPrefs.GetInt("soundNum");
                    settingsController.GameSoundState(false, false, false, false, false, false, false,
                        false,
                        false);
                }

                _rewardedAdAdHealth.Show((Reward reward) =>
                {
                    // TODO: Reward the user.

                   
                    
                    playerTrigger.healthBar.GetComponent<Renderer>().material =
                        playerTrigger.healthbarGreen;
                    playerTrigger.healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
                    countShowRewardedClick = 0;
                    isAdsShownRewardedHealth = true;
                    Debug.Log("can reklami gosterildi");
                    showRewardedAdsButton.SetActive(false); // ödüllü reklamı açan buton kapandı
                    
                });
                
            }
            else
            {
                NoShowRewardedAdHealth();
            }
            RegisterReloadHandlerAdHealth(_rewardedAdAdHealth);
        }
        else
        {
            Debug.Log("ekstra can için buralara kadar geldik");
            playerTrigger.healthBar.GetComponent<Renderer>().material =
                playerTrigger.healthbarGreen;
            playerTrigger.healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
            isAdsShownRewardedHealth = true;
            showRewardedAdsButton.SetActive(false); // ödüllü reklamı açan buton kapandı
        }
    }


    private void RegisterReloadHandlerAdHealth(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
/////            Debug.Log("Rewarded Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAdHealth();
            //sesleri eski haline çevir
            if (musicManager != null)
            {
                if (lastMusicNum == 1)
                {
                    musicManager.StartMusic();
                }
            }

            if (settingsController != null)
            {
                if (lastSoundNum == 1)
                {
                    settingsController.GameSoundState(true, true, true, true, true, true, true, true, true);
                }
            }
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAdHealth();
        };
      
    }

    private void HealthRegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { Debug.Log("Rewarded ad recorded an impression."); };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { Debug.Log("Rewarded ad was clicked."); };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { Debug.Log("Rewarded ad full screen content opened."); };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () => { Debug.Log("Rewarded ad full screen content closed."); };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    public void LoadRewardedAdditionalMoney()
    {
        isAdsShownRewarded = false;
        // Clean up the old ad before loading a new one.
        if (_rewardedAdAdsAdditionalMoney != null)
        {
            _rewardedAdAdsAdditionalMoney.Destroy();
            _rewardedAdAdsAdditionalMoney = null;
        }

/////        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adRewardedUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

/////                Debug.Log("Rewarded ad loaded with response : "
/////                          + ad.GetResponseInfo());

                _rewardedAdAdsAdditionalMoney = ad;
                if (adsTestTxt4 != null)
                {
                    adsTestTxt4.text = "_ad = rewardedAd dditionalMoney";
                }

                Debug.Log("_ad = rewardedAd");
                AdditionalMoneyRegisterEventHandlers(_rewardedAdAdsAdditionalMoney);
            });
    }

    public void ShowRewardedAdsAdditionalMoney()
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (_rewardedAdAdsAdditionalMoney != null && _rewardedAdAdsAdditionalMoney.CanShowAd())
        {
            //sesleri kapat
            if (musicManager != null)
            {
                lastMusicNum = PlayerPrefs.GetInt("musicNum");
                musicManager.StopMusic();
            }

            if (settingsController != null)
            {
                lastSoundNum = PlayerPrefs.GetInt("soundNum");
                settingsController.GameSoundState(false, false, false, false, false, false, false, false,
                    false);
            }

            _rewardedAdAdsAdditionalMoney.Show((Reward reward) =>
            {
                // TODO: Reward the user.
              //  additionalMoneyCount--;
              //  if (additionalMoneyCount == 0)
              //  {
              //      additionalMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
              //      additionalMoneyCount = 1;
              //  }

                isAdsShownRewarded = true;
                GameEconomy.sCoinCount += 200;
                gameEconomy.CoinText();
                coinAnim.SetBool("isCoinAdd", true);
                Debug.Log("para eklendi");
                additionalMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
            });
            RegisterReloadHandlerAdsAdditionalMoney(_rewardedAdAdsAdditionalMoney);
        }
        else
        {
           NoShowRewardedAdsAdditionalMoney();
        }
    }

    private void RegisterReloadHandlerAdsAdditionalMoney(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
/////            Debug.Log("Rewarded Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAdditionalMoney();
            //sesleri eski haline çevir
            if (musicManager != null)
            {
                if (lastMusicNum == 1)
                {
                    musicManager.StartMusic();
                }
            }

            if (settingsController != null)
            {
                if (lastSoundNum == 1)
                {
                    settingsController.GameSoundState(true, true, true, true, true, true, true, true, true);
                }
            }
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAdditionalMoney();
        };
      
    }

    private void AdditionalMoneyRegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () => { Debug.Log("Rewarded ad recorded an impression."); };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () => { Debug.Log("Rewarded ad was clicked."); };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () => { Debug.Log("Rewarded ad full screen content opened."); };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () => { Debug.Log("Rewarded ad full screen content closed."); };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    #endregion


    public void NoShowRewardedAdHealth()
    {
      
        playerTrigger.healthBar.GetComponent<Renderer>().material = playerTrigger.healthbarGreen;
        playerTrigger.healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
        isAdsShownRewardedHealth = true;
        showRewardedAdsButton.SetActive(false); // ödüllü reklamı açan buton kapandı
    }

    public void NoShowRewardedAdsAdditionalMoney()
    {
       // additionalMoneyCount--;
       // if (additionalMoneyCount == 0)
       // {
       //   
       //     additionalMoneyCount = 1;
       //     additionalMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
       // }

        isAdsShownRewarded = true;
        GameEconomy.sCoinCount += 200;
        gameEconomy.CoinText();
        coinAnim.SetBool("isCoinAdd", true);
        additionalMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
    }
}