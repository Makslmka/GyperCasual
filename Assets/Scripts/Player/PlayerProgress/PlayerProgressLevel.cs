using UnityEngine;

public class PlayerProgressLevel : MonoBehaviour
{
    public int ProgressLevel => _progressLevel;

    [SerializeField] private int _progressLevel;
    [SerializeField] private int _increaseCoefficient;

    public void ChangeProgressLevel(int amount)
    {
        _progressLevel += amount;

        if (_progressLevel < 0)
        {
            _progressLevel = 0;
        }
    }

    public void SetProgressLevel(int value)
    { 
        _progressLevel = value * _increaseCoefficient;
    }
}
