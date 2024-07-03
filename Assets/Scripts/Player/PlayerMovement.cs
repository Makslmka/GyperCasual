using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedHorizontal;

    public void Move(float horizontal)
    {
        float deltaTime = Time.deltaTime;

        Vector3 newPos = new (horizontal * deltaTime * _speedHorizontal, 0, deltaTime * _speed);

        _playerTransform.Translate(newPos);

        //_playerTransform.position += newPos;
    }

    public void MovePhysics(float horizontal)
    {
        Vector3 newVelocityZ = transform.TransformVector(horizontal * _speedHorizontal, 0.0f, _speed);
        _rigidbody.velocity = newVelocityZ;
        //_rigidbody.velocity = new Vector3(horizontal * _speedHorizontal, 0.0f, _speed);
        //if (horizontal == 0)
        //{
        //    _rigidbody.velocity = new Vector3(0.0f, 0.0f, _rigidbody.velocity.z);
        //}
        //else
        //{
        //    _rigidbody.AddForce(horizontal * _speedHorizontal, 0.0f, 0.0f);
        //}
    }

    public void StopMove()
    { 
        _rigidbody.velocity = Vector3.zero;
    }
}
