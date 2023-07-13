using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class BannerAD : MonoBehaviour
{
    [SerializeField] private string androidID;
    [SerializeField] private string iosID;
    private void Awake()
    {
        InitADUnit();
    }
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
    BannerView _bannerView;
    public void CreateBannerView()
    {
        if (_bannerView != null)
        {
            DestroyAd();
        }
        _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Top);
    }
    public void LoadAd()
    {
        if (_bannerView == null)
        {
            CreateBannerView();
        }
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        Debug.Log("Loading banner ad.");
        _bannerView.LoadAd(adRequest);
    }
    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

}
