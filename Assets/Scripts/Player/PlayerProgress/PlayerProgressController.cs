using UnityEngine;

public class PlayerProgressController : MonoBehaviour
{
    [SerializeField] private PlayerProgressLevel _playerProgressLevel;
    [SerializeField] private PlayerPhaseContorller _playerPhaseContorller;

    public void SetNewProgressLevel(int value)
    { 
        _playerProgressLevel.SetProgressLevel(value);

        _playerPhaseContorller.TryToChangePhase(_playerProgressLevel.ProgressLevel);
    }

    public void ChangePlayerPhase()
    {
        _playerPhaseContorller.TryToChangePhase(_playerProgressLevel.ProgressLevel);
    }

    private void ChangePlayerProgress(int amount)
    {
        _playerProgressLevel.ChangeProgressLevel(amount);

        _playerPhaseContorller.TryToChangePhase(_playerProgressLevel.ProgressLevel);
    }

    private void OnEnable()
    {
        EventBus.GatePlayerEntered += ChangePlayerProgress;
    }

    private void OnDisable()
    {
        EventBus.GatePlayerEntered -= ChangePlayerProgress;
    }
}
