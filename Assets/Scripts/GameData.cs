using UnityEngine;
using System;

public class GameData : MonoBehaviour
{
    public static event Action<int> OnHealthTowerLoaded;
    public static event Action<int> OnCoinsLoaded;
    public static event Action<int> OnLevelLoaded;
    public static event Action<int, string> OnPurchaseLevelLoaded;
    public static event Action GameDataLoaded;

    private const string HealthTowerStr = "HealthTower";
    private const string CoinsStr = "Coins";
    private const string ProgressStr = "Progress";
    private const string CoinsCoeffStr = "CoinsCoeff";
    private const string LevelStr = "LevelCoeff";

    private int _healthTowerInt;
    private int _coinsInt;
    private int _purchaseLevel;
    private int _level;

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    { 
        LoadCoins();
        LoadPurchaseLevel(ProgressStr);
        LoadPurchaseLevel(CoinsCoeffStr);
        LoadLevel();
        GameDataLoaded?.Invoke();
        LoadHealthTower();
    }

    public static void SaveHealthTower(int value)
    {
        PlayerPrefs.SetInt(HealthTowerStr, value);
        PlayerPrefs.Save();
    }

    public static void SaveCoins(int value)
    {
        PlayerPrefs.SetInt(CoinsStr, value);
        PlayerPrefs.Save();
    }

    public static void SavePurchaseLevel(int value, string levelId)
    {
        PlayerPrefs.SetInt(levelId, value);
        PlayerPrefs.Save();
    }

    public static void SaveLevel(int value)
    {
        PlayerPrefs.SetInt(LevelStr, value);
        PlayerPrefs.Save();
    }

    private void LoadHealthTower()
    {
        if (PlayerPrefs.HasKey(HealthTowerStr))
        {
            _healthTowerInt = PlayerPrefs.GetInt(HealthTowerStr);
        }
        else
        {
            _healthTowerInt = 100;
        }

        OnHealthTowerLoaded?.Invoke(_healthTowerInt);
    }

    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey(CoinsStr))
        {
            _coinsInt = PlayerPrefs.GetInt(CoinsStr);
        }
        else
        {
            _coinsInt = 0;
        }

        OnCoinsLoaded?.Invoke(_coinsInt);
    }

    private void LoadPurchaseLevel(string levelId)
    {
        if (PlayerPrefs.HasKey(levelId))
        {
            _purchaseLevel = PlayerPrefs.GetInt(levelId);
        }
        else
        {
            _purchaseLevel = 1;
        }

        OnPurchaseLevelLoaded?.Invoke(_purchaseLevel, levelId);
    }

    private void LoadLevel()
    {
        if (PlayerPrefs.HasKey(LevelStr))
        {
            _level = PlayerPrefs.GetInt(LevelStr);
        }
        else
        {
            _level = 1;
        }

        OnLevelLoaded?.Invoke(_level);
    }
}
