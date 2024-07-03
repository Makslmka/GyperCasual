using UnityEngine;

public class GateSoundSpawner : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _clipPositive;
    [SerializeField] private AudioClip _clipNegative;

    public void PlaySoundAtPoint()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, transform.position, _audioSource.volume);
    }

    public void SetAudioClip(int value)
    {
        _audioSource.clip = value >= 0 ? _clipPositive : _clipNegative;
    }
}
