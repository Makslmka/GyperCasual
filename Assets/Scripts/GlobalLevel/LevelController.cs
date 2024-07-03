using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int Level => _level;

    [SerializeField] private int _level;

    private void Awake()
    {
        GameData.OnLevelLoaded += SetStartLevel;
    }

    public void IncreaseLevel()
    { 
        _level += 1;

        GameData.SaveLevel(_level);
    }

    private void SetStartLevel(int value)
    { 
        _level = value;

        EventBus.SendLevel(_level);
    }

    private void OnDisable()
    {
        GameData.OnLevelLoaded -= SetStartLevel;
    }
}
