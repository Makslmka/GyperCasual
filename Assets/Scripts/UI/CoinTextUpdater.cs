using UnityEngine;
using TMPro;

public class CoinTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;

    private void UpdateText(int value)
    { 
        _coinText.text = value.ToString();
    }

    private void OnEnable()
    {
        EventBus.CoinsChanged += UpdateText;
    }

    private void OnDisable()
    {
        EventBus.CoinsChanged -= UpdateText;
    }
}
