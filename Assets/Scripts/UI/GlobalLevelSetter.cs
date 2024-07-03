using TMPro;
using UnityEngine;

public class GlobalLevelSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void SetTextLevel(int value)
    { 
        _text.text = value.ToString();
    }

    private void OnEnable()
    {
        EventBus.LevelSeted += SetTextLevel;
    }

    private void OnDisable()
    {
        EventBus.LevelSeted -= SetTextLevel;
    }
}
