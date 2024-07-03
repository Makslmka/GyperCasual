using UnityEngine;

public class Deactivator : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    public void DeactivateGameObject()
    {
        if (_gameObject != null)
            _gameObject.SetActive(false);
    }
}
