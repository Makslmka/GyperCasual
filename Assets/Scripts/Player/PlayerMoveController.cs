using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerBarrier _playerBarrier;

    private bool _isMoving = false;

    private void FixedUpdate()
    {
        if (_isMoving)
        {
            if (Input.GetMouseButton(0))
            {
                EventBus.PlayerStartRun();

                _playerInput.SetHorizontalAxis();

                _playerMovement.MovePhysics(_playerInput.Horizontal);

                //_playerBarrier.AdjustPosition();
            }
            else
            {
                _playerMovement.StopMove();
                EventBus.PlayerStopRun();
            }
        }
    }

    public void StopMoving()
    { 
        _isMoving = false;
    }

    public void StartMoving()
    {
        _isMoving = true; 
    }
}
