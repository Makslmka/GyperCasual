using UnityEngine;

public class ObjectsList : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsList;

    private int _randomObject;

    public GameObject GetOne()
    { 
        _randomObject = Random.Range(0, _prefabsList.Length);

        return _prefabsList[_randomObject];
    }
}
