using UnityEngine;

public class TowerAnimateDestroing : MonoBehaviour
{
    [SerializeField] private GameObject _tower;
    [SerializeField] private GameObject _particle;
    [SerializeField] private AudioSource _audioSource;

    public void DestroyTower()
    { 
        _particle.SetActive(true);
        _tower.SetActive(false);
        _audioSource.Play();
    }
}
