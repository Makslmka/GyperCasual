using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlaySoundAtPoint()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position, _audioSource.volume);
    }
}
