using UnityEngine;

public class WalletTemp : MonoBehaviour
{
    public int CoinsCount => _coinCount;

    [SerializeField] private CoinMultiplier _coinMultiplier;
    [SerializeField] private int _coinCount;

    public void AddCoins(int count)
    {
        _coinCount += count;
    }
}
