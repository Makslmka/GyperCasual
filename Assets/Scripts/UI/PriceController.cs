using TMPro;
using UnityEngine;

public class PriceController : MonoBehaviour
{
    public int Price => _price;

    [SerializeField] private int _price;
    [SerializeField] private float _increaseCoefficient;
    [SerializeField] private TextMeshProUGUI _text;

    public void IncreasePrice()
    { 
        float newPrice = _price * _increaseCoefficient;
        _price = Mathf.RoundToInt(newPrice);
        SetNewPrice();
    }

    public void SetStartPrice(int level)
    {
        for (int i = 1; i < level; i++)
        {
            IncreasePrice();
        }
    }

    private void SetNewPrice()
    { 
        _text.text = _price.ToString();
    }

    private void OnEnable()
    {
        SetNewPrice();
    }
}
