using UnityEngine;

public class PurchaseLevel : MonoBehaviour
{
    public int LevelValue => _levelValue;

    [SerializeField] private string _levelId;
    [SerializeField] private int _levelValue;

    private void Awake()
    {
        GameData.OnPurchaseLevelLoaded += SetStartValue;
    }

    private void SetStartValue(int value, string levelId)
    {
        if (levelId == _levelId)
        {
            _levelValue = value;
        }
    }

    public void IncreaseLevel()
    { 
        _levelValue += 1;
        GameData.SavePurchaseLevel(_levelValue, _levelId);
    }

    private void OnDisable()
    {
        GameData.OnPurchaseLevelLoaded -= SetStartValue;
    }
}
