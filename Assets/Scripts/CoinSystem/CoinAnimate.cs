using UnityEngine;

public class CoinAnimate : MonoBehaviour
{
    [SerializeField] private Transform _coinTransform;
    [SerializeField] private Vector3 _speedRotation;

    private void Update()
    {
        Vector3 newRotate = _speedRotation * Time.deltaTime;

        _coinTransform.Rotate(newRotate);
    }
}
