using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    public void Spawn(GameObject gameObject)
    {
        _spawner.Spawn(gameObject);
    }
}
