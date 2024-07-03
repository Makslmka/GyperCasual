using UnityEngine;

public class TowerHealhController : MonoBehaviour
{
    [SerializeField] private TowerHealth _towerHealth;
    [SerializeField] private PlayerProgressLevel _playerProgressLevel;
    [SerializeField] private TowerText _towerText;
    [SerializeField] private TowerAnimateDestroing _towerAnimateDestroing;

    private void Awake()
    {
        GameData.OnHealthTowerLoaded += TrySetNewHealthTower;
    }

    private void Start()
    {
        
    }

    private void TrySetNewHealthTower(int value)
    {
        _towerHealth.TrySetNewHealth(value, _playerProgressLevel.ProgressLevel);

        _towerText.SetText(_towerHealth.HealthTower);
    }

    public void ChangeTowerHealth()
    {
        _towerHealth.TakeHealth(_playerProgressLevel.ProgressLevel);

        GameData.SaveHealthTower(_towerHealth.HealthTower);
        
        _towerText.SetText(_towerHealth.HealthTower);

        if (_towerHealth.HealthTower <= 0)
        {
            _towerAnimateDestroing.DestroyTower();
        }
    }

    private void OnDisable()
    {
        GameData.OnHealthTowerLoaded -= TrySetNewHealthTower;
    }
}
