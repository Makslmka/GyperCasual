using UnityEngine;

public class CoinMultiplier : MonoBehaviour
{
    [SerializeField] private float _coefficient;
    [SerializeField] private float _increaseCoefficient;

    private float _startCoefficient;

    private void Awake()
    {
        _startCoefficient = _coefficient;
    }

    public int MultipleCoins(int coinsAmount)
    {
        float floatCoinsAmount = _coefficient + coinsAmount;

        int newCoinsAmount = Mathf.RoundToInt(floatCoinsAmount);

        return newCoinsAmount;
    }

    public int MultipleCoins(int coinsAmount, float coefficient)
    {
        float floatCoinsAmount = coefficient + coinsAmount;

        int newCoinsAmount = Mathf.RoundToInt(floatCoinsAmount);

        return newCoinsAmount;
    }

    public void SetNewCoefficient(int level)
    {
        float newCoefficient = _startCoefficient;

        for (int i = 1; i < level; i++)
        {
            newCoefficient += _increaseCoefficient;
        }

        _coefficient = newCoefficient;
    }
}
