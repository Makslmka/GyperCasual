using UnityEngine;

public class InstantiateController : MonoBehaviour
{
    [SerializeField] private SpawnPointsController _spawnPointsController;
    [SerializeField] private ObjectsList _objectsList;

    private void Start()
    {
        foreach (var point in _spawnPointsController.PointsList)
        {
            point.Spawn(_objectsList.GetOne());
        }
    }
}
