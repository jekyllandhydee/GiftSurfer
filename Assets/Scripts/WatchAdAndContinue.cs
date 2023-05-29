using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAdAndContinue : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] GameObject _failMenu;

    bool _subbed = false;

    private void OnDisable()
    {
        if (!_subbed)
            return;

        AdManager.OnRewarded -= GiveReward;
    }

    public void ButtonClick()
    {
        _subbed = true;
        AdManager.OnRewarded += GiveReward;
        AdManager.Instance.ShowRewardedAd();
    }

    void GiveReward()
    {
        _player.position += _player.forward * 3f;
        Time.timeScale = 1f;
        _failMenu.SetActive(false);

        AdManager.OnRewarded -= GiveReward;
        _subbed = false;
    }
}
