using UnityEngine;

public class MenuAds : MonoBehaviour
{
    private void OnEnable()
    {
        AdManager.OnAdsSet += SetAds;
    }

    private void OnDisable()
    {
        AdManager.OnAdsSet -= SetAds;
    }

    void SetAds()
    {
        AdManager.Instance.ShowBannerAd();
        float rnd = Random.Range(0f, 1f);

        if (rnd < 0.5f)
        {
            AdManager.Instance.ShowSplashImage();
            return;
        }

        AdManager.Instance.ShowSplashVideo();
    }
}
