using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;
using HuaweiMobileServices.Ads;
using System;

public class AdManager : MonoBehaviour
{
    public static event Action OnAdsSet;
    public static event Action OnRewarded;

    //private Toggle testAdStatusToggle;
    private readonly string TAG = "[HMS] AdManager: ";

    [SerializeField] string splashImg = "testq6zq98hecj";
    [SerializeField] string splashVideo = "testd7c5cewoj6";

    #region Singleton

    public static AdManager Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    private void Awake()
    {
        Singleton();
    }

    private void Start()
    {
        HMSAdsKitManager.Instance.OnRewarded = ReceiveReward;
        HMSAdsKitManager.Instance.OnInterstitialAdClosed = OnInterstitialAdClosed;

        HMSAdsKitManager.Instance.ConsentOnFail = OnConsentFail;
        HMSAdsKitManager.Instance.ConsentOnSuccess = OnConsentSuccess;
        HMSAdsKitManager.Instance.RequestConsentUpdate();

        //testAdStatusToggle = GameObject.FindGameObjectWithTag("Toggle").GetComponent<Toggle>();
        //testAdStatusToggle.isOn = HMSAdsKitSettings.Instance.Settings.GetBool(HMSAdsKitSettings.UseTestAds);


        #region SetNonPersonalizedAd , SetRequestLocation

        var builder = HwAds.RequestOptions.ToBuilder();

        builder
            .SetConsent("tcfString")
            .SetNonPersonalizedAd((int)NonPersonalizedAd.ALLOW_ALL)
            .Build();

        bool requestLocation = true;
        var requestOptions = builder.SetConsent("testConsent").SetRequestLocation(requestLocation).Build();

        Debug.Log($"{TAG}RequestOptions NonPersonalizedAds:  {requestOptions.NonPersonalizedAd}");
        Debug.Log($"{TAG}Consent: {requestOptions.Consent}");

        #endregion

        OnAdsSet?.Invoke();
    }

    private void OnConsentSuccess(ConsentStatus consentStatus, bool isNeedConsent, IList<AdProvider> adProviders)
    {
        Debug.Log($"{TAG}OnConsentSuccess consentStatus:{consentStatus} isNeedConsent:{isNeedConsent}");
        foreach (var AdProvider in adProviders)
        {
            Debug.Log($"{TAG}OnConsentSuccess adproviders: Id:{AdProvider.Id} Name:{AdProvider.Name} PrivacyPolicyUrl:{AdProvider.PrivacyPolicyUrl} ServiceArea:{AdProvider.ServiceArea}");
        }
    }

    private void OnConsentFail(string desc)
    {
        Debug.LogError($"{TAG}OnConsentFail:{desc}");
    }

    public void ShowBannerAd()
    {
        Debug.Log($"{TAG}ShowBannerAd");

        HMSAdsKitManager.Instance.ShowBannerAd();
    }

    public void HideBannerAd()
    {
        Debug.Log($"{TAG}HideBannerAd");

        HMSAdsKitManager.Instance.HideBannerAd();
    }

    public void ShowRewardedAd()
    {
        Debug.Log($"{TAG}ShowRewardedAd");
        HMSAdsKitManager.Instance.ShowRewardedAd();
    }

    public void ShowInterstitialAd()
    {
        Debug.Log($"{TAG}ShowInterstitialAd");
        HMSAdsKitManager.Instance.ShowInterstitialAd();
    }

    public void ShowSplashImage()
    {
        Debug.Log($"{TAG}ShowSplashImage!");

        HMSAdsKitManager.Instance.LoadSplashAd(splashImg, SplashAd.SplashAdOrientation.PORTRAIT);
    }

    public void ShowSplashVideo()
    {
        Debug.Log($"{TAG}ShowSplashVideo!");

        HMSAdsKitManager.Instance.LoadSplashAd(splashVideo, SplashAd.SplashAdOrientation.PORTRAIT);
    }

    public void ReceiveReward(Reward reward)
    {
        OnRewarded?.Invoke();
        Debug.Log($"{TAG}rewarded!");
    }

    public void OnInterstitialAdClosed()
    {
        Debug.Log($"{TAG}interstitial ad closed");
    }

    public void SetTestAdStatus()
    {
        // HMSAdsKitManager.Instance.SetTestAdStatus(testAdStatusToggle.isOn);
        HMSAdsKitManager.Instance.SetTestAdStatus(HMSAdsKitSettings.Instance.Settings.GetBool(HMSAdsKitSettings.UseTestAds));
        HMSAdsKitManager.Instance.DestroyBannerAd();
        HMSAdsKitManager.Instance.LoadAllAds();
    }
}
