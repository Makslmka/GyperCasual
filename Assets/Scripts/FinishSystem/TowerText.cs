using TMPro;
using UnityEngine;

public class TowerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(int value)
    {
        if (value > 0)
        {
            _text.text = value.ToString();
        }
        else
        {
            _text.text = string.Empty;
        }
    }
}
