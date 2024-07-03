using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _barImage;

    private void ChangeProgressBar(int current, int max)
    {
        float value = (float)current / (float)max;
        
        _barImage.fillAmount = value;//Mathf.Clamp(value, 0f, 1f);
    }

    private void OnEnable()
    {
        EventBus.ProgressLevelChanged += ChangeProgressBar;
    }

    private void OnDisable()
    {
        EventBus.ProgressLevelChanged -= ChangeProgressBar;
    }
}
