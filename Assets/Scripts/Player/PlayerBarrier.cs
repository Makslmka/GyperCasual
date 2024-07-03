using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _leftBarrierPos;
    [SerializeField] private float _rightBarrierPos;

    public void AdjustPosition()
    {
        float positionX = Mathf.Clamp(_playerTransform.position.x, _leftBarrierPos, _rightBarrierPos);

        Vector3 newPlayerPostion = new (positionX, _playerTransform.position.y, _playerTransform.position.z);

        _playerTransform.position = newPlayerPostion;
    }

    public void AdjustPositionPhysics()
    {
        if (_playerTransform.position.x <= _leftBarrierPos)
        {
            _playerRigidbody.velocity = new Vector3(0, _playerRigidbody.velocity.y, _playerRigidbody.velocity.z);
        }
        if (_playerTransform.position.x >= _rightBarrierPos) 
        {
            _playerRigidbody.velocity = new Vector3(0, _playerRigidbody.velocity.y, _playerRigidbody.velocity.z);
        }
    }
}
