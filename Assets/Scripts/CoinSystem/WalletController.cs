using UnityEngine;

public class WalletController : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private WalletTemp _walletTemp;
    [SerializeField] private CoinMultiplier _coinMultiplier;

    public int GetCoinsAmount()
    {
        return _wallet.CoinCount;
    }

    public void CoinTransition()
    {
        _wallet.AddCoins(_walletTemp.CoinsCount);

        GameData.SaveCoins(_wallet.CoinCount);

        EventBus.SendCoins(_wallet.CoinCount);
    }

    public void SpendCoins(int value)
    { 
        _wallet.ReduceCoins(value);

        GameData.SaveCoins(_wallet.CoinCount);

        EventBus.SendCoins(_wallet.CoinCount);
        EventBus.CoinsSpending();
    }

    private void IncreaseCoins(int value)
    { 
        int coins = _coinMultiplier.MultipleCoins(value);

        _wallet.AddCoins(coins);
        _walletTemp.AddCoins(coins);

        GameData.SaveCoins(_wallet.CoinCount);

        EventBus.SendCoins(_wallet.CoinCount);
    }

    private void SetSartCoins(int value)
    { 
        _wallet.SetCoins(value);

        //_wallet.SetCoins(15000);

        EventBus.SendCoins(_wallet.CoinCount);
    }

    private void OnEnable()
    {
        EventBus.CoinPickedUp += IncreaseCoins;
        GameData.OnCoinsLoaded += SetSartCoins;
    }

    private void OnDisable()
    {
        EventBus.CoinPickedUp -= IncreaseCoins;
        GameData.OnCoinsLoaded -= SetSartCoins;
    }
}
