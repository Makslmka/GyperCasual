using UnityEngine;

public class PlayerPhaseContorller : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerPhases;
    [SerializeField] private int[] _costPhase;

    [SerializeField] private int _maxLevel = 0;
    [SerializeField] private int _currentLevel = 0;

    public void TryToChangePhase(int progressLevel)
    {
        for (int i = 0; i < _costPhase.Length - 1; i++)
        {
            if (progressLevel >= _costPhase[i])
            {
                _playerPhases[i].SetActive(true);

                _maxLevel = _costPhase[i + 1] - _costPhase[i];
                _currentLevel = progressLevel - _costPhase[i];
                for (int j = 0; j < i; j++)
                {
                    _playerPhases[j].SetActive(false);
                }
            }
            else
            {
                _playerPhases[i].SetActive(false);
            }
        }

         

        EventBus.SendProgressLevel(_currentLevel, _maxLevel);
    }
}
