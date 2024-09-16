using CrazyGames;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditCrazySDKLoadingScene : MonoBehaviour
{
    [Header("Control")] public MusicManager musicManager;
    public SettingsController settingsController;
    public GameEconomy gameEconomy;

    public PlayerTrigger playerTrigger;

    // public AnimationEvents bodyAnimationEvents;
    [Header("Music")] private int lastMusicNum;
    private int lastSoundNum;
    [Header("Button")] public GameObject showRewardedAdsButton;
    public GameObject additionalMoneyButton;

    [Header("Text")] public int additionalMoneyCount = 2;
//    public TextMeshProUGUI additionalMoneyCountText;

    //public GameObject tutorialFirstAdsPanel;


  
    public Animator coinAnim;
    private int countShowRewardedClick;
    private bool idLoadRewardedAd;


    [SerializeField] private CrazyAdType adType = CrazyAdType.Midgame;

    void Start()
    {
        if (CrazySDK.IsAvailable)
        {
            CrazySDK.Init(() => { Debug.Log("CrazySDK initialized"); });
        }

        musicManager = FindObjectOfType<MusicManager>();
        lastMusicNum = PlayerPrefs.GetInt("musicNum");
        lastSoundNum = PlayerPrefs.GetInt("soundNum");

    }

    public void ShowRewardedAdHealth() //reklam açılınca müzikleri kapat // oyunu durdur
    {
        print("Player Died! Requesting ad " + adType);
        CrazySDK.Ad.RequestAd(
            adType,
            () =>
            {
                countShowRewardedClick++;
                if (countShowRewardedClick == 3)
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
                }

                Time.timeScale = 0;
            },
            (error) =>
            {
                enabled = false;
                print("Ad error, not respawning: " + error);
            },
            () =>
            {
                Time.timeScale = 1;
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

                showRewardedAdsButton.SetActive(false); // ödüllü reklamı açan buton kapandı
                playerTrigger.healthBar.GetComponent<Renderer>().material = playerTrigger.healthbarGreen;
                playerTrigger.healthBar.transform.localScale = new Vector3(.6f, 0.07f, 0.02f);
                countShowRewardedClick = 0;
              
            }
        );
    }


    public void ShowRewardedAdsAdditionalMoney()
    {
        print("Player Died! Requesting ad " + adType);
        CrazySDK.Ad.RequestAd(
            adType,
            () =>
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


                Time.timeScale = 0;
            },
            (error) =>
            {
                enabled = false;
                print("Ad error, not respawning: " + error);
            },
            () =>
            {
                Time.timeScale = 1;
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

                additionalMoneyCount--;
                if (additionalMoneyCount == 0)
                {
                    additionalMoneyButton.SetActive(false); // ödüllü reklamı açan buton kapandı
                    additionalMoneyCount = 1;
                }
                
                GameEconomy.sCoinCount += 200;
                gameEconomy.CoinText();
                coinAnim.SetBool("isCoinAdd", true);
            }
        );
    }
}