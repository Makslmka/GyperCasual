using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private string _triggerAttack;
    [SerializeField] private string _boolRunning;

    private void StartRun()
    {
        _animator.SetBool(_boolRunning, true);
    }

    private void StopRun() 
    {
        _animator.SetBool(_boolRunning, false);
    }

    private void SetTriggerAttack()
    {
        _animator.SetTrigger(_triggerAttack);
    }

    private void OnEnable()
    {
        EventBus.PlayerStartRunning += StartRun;
        EventBus.PlayerStopRunning += StopRun;
        EventBus.PlayerAttacking += SetTriggerAttack;
    }

    private void OnDisable()
    {
        EventBus.PlayerStartRunning -= StartRun;
        EventBus.PlayerStopRunning -= StopRun;
        EventBus.PlayerAttacking -= SetTriggerAttack;
    }
}
