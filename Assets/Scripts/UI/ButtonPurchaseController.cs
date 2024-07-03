using UnityEngine;
using UnityEngine.Events;

public class ButtonPurchaseController : MonoBehaviour
{
    [SerializeField] private string _adId;
    [Space]
    [SerializeField] private GameObject _enoughCoins;
    [SerializeField] private GameObject _notEnoughCoins;
    [Space]
    [SerializeField] private WalletController _walletController;
    [SerializeField] private PriceController _priceController;
    [SerializeField] private PurchaseLevel _purchaseLevel;
    [Space]
    [SerializeField] private UnityEvent<int> _levelChanged;

    private YandexSDK _yandexSDK;

    private bool _isEnoughCoins;

    private void Awake()
    {
        

        GameData.GameDataLoaded += SetStartValues;
    }

    private void Start()
    {
        _yandexSDK = YandexSDK.instance;

        _yandexSDK.onRewardedAdOpened += RewardedAdOpen;
        _yandexSDK.onRewardedAdReward += RewardedAdReward;
        _yandexSDK.onRewardedAdClosed += RewardedAdClose;
        _yandexSDK.onRewardedAdError += RewardedAdError;
    }

    public void TryToPurchaseUpgrade()
    {
        if (_isEnoughCoins)
        {
            _walletController.SpendCoins(_priceController.Price);

            _purchaseLevel.IncreaseLevel();

            _priceController.IncreasePrice();

            _levelChanged.Invoke(_purchaseLevel.LevelValue);
        }
        else
        {
            ShowRewardedAd();
        }

        CheckCoinsForPurchase();
    }

    private void CheckCoinsForPurchase()
    {
        int coinsAmount = _walletController.GetCoinsAmount();

        if (coinsAmount < _priceController.Price)
        {
            _enoughCoins.SetActive(false);
            _notEnoughCoins.SetActive(true);
            _isEnoughCoins = false;
        }
        else 
        {
            _enoughCoins.SetActive(true);
            _notEnoughCoins.SetActive(false);
            _isEnoughCoins = true;
        }
    }

    private void SetStartValues()
    { 
        _priceController.SetStartPrice(_purchaseLevel.LevelValue);

        _levelChanged.Invoke(_purchaseLevel.LevelValue);

        CheckCoinsForPurchase();
    }

    private void ShowRewardedAd()
    {
        _yandexSDK.ShowRewarded(_adId);
    }

    private void RewardedAdOpen(int id)
    {

    }

    private void RewardedAdReward(string id)
    {
        if (id == _adId)
        {
            _purchaseLevel.IncreaseLevel();

            _priceController.IncreasePrice();

            _levelChanged.Invoke(_purchaseLevel.LevelValue);
        }

        CheckCoinsForPurchase();
    }

    private void RewardedAdClose(int id)
    {

    }

    private void RewardedAdError(string id)
    {

    }

    private void OnEnable()
    {
        EventBus.CoinsSpended += CheckCoinsForPurchase;
    }

    private void OnDisable()
    {
        GameData.GameDataLoaded -= SetStartValues;

        EventBus.CoinsSpended -= CheckCoinsForPurchase;

        _yandexSDK.onRewardedAdOpened -= RewardedAdOpen;
        _yandexSDK.onRewardedAdReward -= RewardedAdReward;
        _yandexSDK.onRewardedAdClosed -= RewardedAdClose;
        _yandexSDK.onRewardedAdError -= RewardedAdError;
    }
}
