using UnityEngine;

public class SpawnPointsController : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    public SpawnPoint[] PointsList => _spawnPoints;
}
