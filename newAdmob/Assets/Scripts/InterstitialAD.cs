using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class InterstitialAD : MonoBehaviour
{
    [SerializeField] private string androidID;
    [SerializeField] private string iosID;

    private string _adUnitId;
    private void InitADUnit()
    {
#if UNITY_ANDROID
        string _adUnitId = androidID;
#elif UNITY_IPHONE
   string _adUnitId =iosID;
#else
   string _adUnitId = "unused";
#endif
    }
    private void Awake()
    {
        InitADUnit();
    }
    private InterstitialAd interstitialAd; 
    public void LoadInterstitialAd()
    { 
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        } 
        var adRequest = new AdRequest(); 
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            { 
              if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
            });
        RegisterEventHandlers(interstitialAd);
    }
    public void ShowAd()
    { 
        if (interstitialAd != null && interstitialAd.CanShowAd())
        { 
            interstitialAd.Show();
        }
        else
        { 
        }
    }
    private void RegisterEventHandlers(InterstitialAd ad)
    { 
        ad.OnAdFullScreenContentClosed += () =>
        {
            LoadInterstitialAd();
        }; 
    }

}
