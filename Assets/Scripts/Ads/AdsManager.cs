using UnityEngine;
using GoogleMobileAds.Api;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class AdsManager : MonoBehaviour
{
    [Header("Control")] public MusicManager musicManager;
    public SettingsController settingsController;
    public WaveControl waveControl;
    public GameEconomy gameEconomy;

    public PlayerTrigger playerTrigger;

    // public AnimationEvents bodyAnimationEvents;
    [Header("Music")] private int lastMusicNum;
    private int lastSoundNum;
    [Header("Button")] public GameObject showRewardedAdsButton;
    public GameObject additionalMoneyButton;
    [Header("Text")] public int additionalMoneyCount = 2;
    public TextMeshProUGUI additionalMoneyCountText;

    public GameObject tutorialFirstAdsPanel;
    public Button upgradeButton;
    public GameObject tutorialHelathAdsPanel;

    public bool isAdsShownRewardedHealth;
    public bool isAdsShownRewarded;

    public Animator coinAnim;
    private int countShowRewardedClick;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        lastMusicNum = PlayerPrefs.GetInt("musicNum");
        lastSoundNum = PlayerPrefs.GetInt("soundNum");
        isAdsShownRewardedHealth = false;
        isAdsShownRewarded = false;
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });
        // LoadAd(); // banner reklam
        LoadInterstitialAd(); // geçiş reklamı
        LoadRewardedAd(); //ödüllü reklam
    }

    private void Update()
    {
        // geçiş reklamını yakalamak için
        if (waveControl != null)
        {
            if (waveControl.isAds)
            {
                ShowInterstitialAd();
                waveControl.isAds = false;
            }
        }
    }

//    #region Banner
//
//    // These ad units are configured to always serve test ads.
//#if UNITY_ANDROID
//  //  private string _adUnitId = "ca-app-pub-6768650963516253/7128626846"; //orjinal
//     private string _adUnitId = "ca-app-pub-3940256099942544/6300978111"; //test
//#elif UNITY_IPHONE
//  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
//#else
//  private string _adUnitId = "unused";
//#endif
//
//    BannerView _bannerView;
//
//    /// <summary>
//    /// Creates a 320x50 banner view at top of the screen.
//    /// </summary>
//    public void CreateBannerView()
//    {
///////        Debug.Log("Creating banner view");
//
//        // If we already have a banner, destroy the old one.
//        if (_bannerView != null)
//        {
//            DestroyBannerView();
//        }
//
//        // Create a 320x50 banner at top of the screen
//        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
//    }
//
//
//    public void LoadAd()
//    {
//        // create an instance of a banner view first.
//        if (_bannerView == null)
//        {
//            CreateBannerView();
//        }
//
//        // create our request used to load the ad.
//        var adRequest = new AdRequest();
//
//        // send the request to load the ad.
///////        Debug.Log("Loading banner ad.");
//        _bannerView.LoadAd(adRequest);
//    }
//
//    /// <summary>
//    /// listen to events the banner view may raise.
//    /// </summary>
//    private void ListenToAdEvents()
//    {
//        // Raised when an ad is loaded into the banner view.
//        _bannerView.OnBannerAdLoaded += () =>
//        {
//            /////       Debug.Log("Banner view loaded an ad with response : "
//            /////                 + _bannerView.GetResponseInfo());
//        };
//        // Raised when an ad fails to load into the banner view.
//        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
//        {
//            Debug.LogError("Banner view failed to load an ad with error : "
//                           + error);
//        };
//        // Raised when the ad is estimated to have earned money.
//        _bannerView.OnAdPaid += (AdValue adValue) =>
//        {
//            /////           Debug.Log(String.Format("Banner view paid {0} {1}.",
///////                adValue.Value,
//            /////               adValue.CurrencyCode));
//        };
//        // Raised when an impression is recorded for an ad.
//        _bannerView.OnAdImpressionRecorded += () =>
//        {
//            /* Debug.Log("Banner view recorded an impression.");*/
//        };
//        // Raised when a click is recorded for an ad.
//        _bannerView.OnAdClicked += () =>
//        {
//            /* Debug.Log("Banner view was clicked.");*/
//        };
//        // Raised when an ad opened full screen content.
//        _bannerView.OnAdFullScreenContentOpened += () =>
//        {
//            /*"Banner view full screen content opened.");*/
//        };
//        // Raised when the ad closed full screen content.
//        _bannerView.OnAdFullScreenContentClosed += () =>
//        {
//            /*"Banner view full screen content closed.");*/
//        };
//    }
//
//    /// <summary>
//    /// Destroys the banner view.
//    /// </summary>
//    public void DestroyBannerView()
//    {
//        if (_bannerView != null)
//        {
///////            Debug.Log("Destroying banner view.");
//            _bannerView.Destroy();
//            _bannerView = null;
//        }
//    }
//
//    #endregion

    #region InterstitialAd

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    //  private string _adInterstitialUnitId = "ca-app-pub-6768650963516253/3341107840"; //orjinal
    private string _adInterstitialUnitId = "ca-app-pub-3940256099942544/1033173712"; //test

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

                _interstitialAd = ad;
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
                settingsController.GameSoundState(false, false, false, false, false, false, false, false, false);
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
/////            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
/////                adValue.Value,
/////                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            /*"Interstitial ad recorded an impression.");*/
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            /* Debug.Log("Interstitial ad was clicked.");*/
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            /////           Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
/////            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
/////            Debug.LogError("Interstitial ad failed to open full screen content " +
/////                           "with error : " + error);
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
    //  private string _adRewardedUnitId = "ca-app-pub-6768650963516253/9654987332"; //orjinal
    private string _adRewardedUnitId = "ca-app-pub-3940256099942544/5224354917"; //test
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
  private string _adUnitId = "unused";
#endif

    private RewardedAd _rewardedAd;

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
        isAdsShownRewarded = false;
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
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

                _rewardedAd = ad;
            });
    }

    public void ShowRewardedAdHealth()
    {
        countShowRewardedClick++;
        if (countShowRewardedClick == 3)
        {
            const string rewardMsg =
                "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

            if (_rewardedAd != null && _rewardedAd.CanShowAd())
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
                    settingsController.GameSoundState(false, false, false, false, false, false, false, false, false);
                }

                if (tutorialHelathAdsPanel != null)
                {
                    tutorialHelathAdsPanel.SetActive(false);
                }

                _rewardedAd.Show((Reward reward) =>
                {
                    // TODO: Reward the user.

                    showRewardedAdsButton.SetActive(false); // ödüllü reklamı açan buton kapandı
                    playerTrigger.healthBar.GetComponent<Renderer>().material = playerTrigger.healthbarGreen;
                    playerTrigger.healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
                    countShowRewardedClick = 0;
                    isAdsShownRewardedHealth = true;
                });
                RegisterReloadHandler(_rewardedAd);
            }
        }
    }


    public void ShowRewardedAdsAdditionalMoney()
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
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
                settingsController.GameSoundState(false, false, false, false, false, false, false, false, false);
            }

            if (tutorialFirstAdsPanel != null)
                if (tutorialFirstAdsPanel.activeInHierarchy)
                {
                    if (upgradeButton != null)
                    {
                        upgradeButton.interactable = true;
                        tutorialFirstAdsPanel.SetActive(false);
                    }
                }

            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                // kullanıcıya verilecek ödül burada yazılacak
                // playerın canı kırmızı olduğunda izlenen reklam
                additionalMoneyCount--;
                additionalMoneyCountText.text = additionalMoneyCount.ToString();


                if (additionalMoneyCount == 0)
                {
                    additionalMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
                    additionalMoneyCount = 2;
                    additionalMoneyCountText.text = additionalMoneyCount.ToString();
                }

                isAdsShownRewarded = true;
                GameEconomy.sCoinCount += 200;
                gameEconomy.CoinText();
                coinAnim.SetBool("isCoinAdd", true);


/////                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));
            });
            RegisterReloadHandler(_rewardedAd);
        }
    }

    private void RegisterReloadHandler(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
/////            Debug.Log("Rewarded Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadRewardedAd();
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
            LoadRewardedAd();
        };
    }

    #endregion
}