using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class ADController : MonoBehaviour
{
    private BannerAD banner;
    private InterstitialAD interstitial;
    private RewardAD reward;

    public static ADController Instance;

    public delegate void OnReward();
    public static event OnReward OnGaveReward;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        banner = GetComponent<BannerAD>();
        interstitial = GetComponent<InterstitialAD>();
        reward = GetComponent<RewardAD>();
    }
    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            interstitial.LoadInterstitialAd();
            reward.LoadRewardedAd();
            ShowBanner();
        });
    }
    public void ShowBanner()
    {
        banner.LoadAd();
    }
    public void ShowInterstitial()
    {
        interstitial.ShowAd();
    }
    public void ShowRewardAd()
    {
        reward.ShowRewardedAd();
    }
    public void GiveReward()
    {
        OnGaveReward?.Invoke();
    }
}
