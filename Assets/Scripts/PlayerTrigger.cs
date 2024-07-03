using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            _triggered.Invoke();
    }
}
