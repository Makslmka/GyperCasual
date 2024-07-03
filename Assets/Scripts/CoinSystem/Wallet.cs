using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int CoinCount => _coinCount;

    [SerializeField] private int _coinCount;

    public void AddCoins(int count)
    {
        _coinCount += count;
    }

    public void SetCoins(int value)
    {
        _coinCount = value;
    }

    public void ReduceCoins(int value) 
    {
        _coinCount -= value;
    }
}
