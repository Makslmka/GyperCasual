using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public int HealthTower => _healthTower;

    [SerializeField] private int _healthTower;

    public void TakeHealth(int value)
    { 
        _healthTower -= value;
    }

    public void SetHealth(int value)
    {
        _healthTower = value;
    }

    public void TrySetNewHealth(int healthValue, int progressLevel)
    {
        if (healthValue > 0)
        {
            _healthTower = healthValue;
            return;
        }
        _healthTower = progressLevel * 15;
    }
}
