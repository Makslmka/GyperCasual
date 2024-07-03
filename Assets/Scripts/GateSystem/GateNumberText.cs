using TMPro;
using UnityEngine;

public class GateNumberText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(int value)
    { 
        _text.text = value.ToString("+#;-#;0");
    }
}
