using UnityEngine;

public class GateColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Color _colorPositive;
    [SerializeField] private Color _colorNegative;

    public void SetColor(int value)
    {
        _spriteRenderer.color = value >= 0 ? _colorPositive : _colorNegative;
    }
}
