using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal => _cursorHorizontal;

    private Vector3 _cursorPosition;
    private float _cursorHorizontal;
    private float _lastCursorPositionX;

    public void SetHorizontalAxis()
    {
        _cursorPosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            _lastCursorPositionX = _cursorPosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            if (_cursorPosition.x > _lastCursorPositionX)
            {
                _cursorHorizontal = 1;
            }
            else if (_cursorPosition.x == _lastCursorPositionX)
            {
                _cursorHorizontal = 0;
            }
            else if (_cursorPosition.x < _lastCursorPositionX)
            {
                _cursorHorizontal = -1;
            }

            _lastCursorPositionX = _cursorPosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _cursorHorizontal = 0;
        }
    }
}
