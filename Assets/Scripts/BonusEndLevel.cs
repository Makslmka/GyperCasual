using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BonusEndLevel : MonoBehaviour
{
    [SerializeField] private WalletTemp _walletTemp;
    [SerializeField] private WalletController _walletController;
    [SerializeField] private TextMeshProUGUI _text;
    [Space]
    [SerializeField] private string _adId;
    [Space]
    [SerializeField] private UnityEvent _onGetBonus;

    private YandexSDK _yandexSDK;

    private void Start()
    {
        _yandexSDK = YandexSDK.instance;

        _yandexSDK.onRewardedAdOpened += RewardedAdOpen;
        _yandexSDK.onRewardedAdReward += RewardedAdReward;
        _yandexSDK.onRewardedAdClosed += RewardedAdClose;
        _yandexSDK.onRewardedAdError += RewardedAdError;

    }

    private void GetBonus()
    {
        _walletController.CoinTransition();

        _onGetBonus.Invoke();
    }

    public void ShowRewardedAd()
    {
        _yandexSDK.ShowRewarded(_adId);
    }

    private void RewardedAdOpen(int id)
    {

    }

    private void RewardedAdReward(string id)
    {
        if (id == _adId)
            GetBonus();
    }

    private void RewardedAdClose(int id)
    {
        //_onGetBonus.Invoke();
    }

    private void RewardedAdError(string id)
    {

    }

    private void OnEnable()
    {
        _text.text = "+" + _walletTemp.CoinsCount.ToString();
    }

    private void OnDisable()
    {
        _yandexSDK.onRewardedAdOpened -= RewardedAdOpen;
        _yandexSDK.onRewardedAdReward -= RewardedAdReward;
        _yandexSDK.onRewardedAdClosed -= RewardedAdClose;
        _yandexSDK.onRewardedAdError -= RewardedAdError;
    }
}
