using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fade_InOut : MonoBehaviour
{
    [SerializeField] private float _timeAnimation;
    [SerializeField] private Image _image;
    [Range(0, 1)][SerializeField] private float _endTransperentLevel;
    [Range(0, 1)][SerializeField] private float _startTransperentLevel;
    [Space]
    [SerializeField] private UnityEvent _onAnimationEnd;
    
    private Color _imageColor;
    private Coroutine _coroutine;

    private void Start()
    {
        // _startTransperentLevel = _image.color.a;
        // _transperentLevel = _image.color;
    }

    private void OnEnable()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        //_startTransperentLevel = _image.color.a;
        _imageColor = _image.color;

        for (float i = 0; i < 1; i += Time.deltaTime / _timeAnimation)
        {
            _imageColor.a = Mathf.Lerp(_startTransperentLevel, _endTransperentLevel, i); ;
            _image.color = _imageColor;
            yield return null;
        }

        _coroutine = null;

        _onAnimationEnd.Invoke();
    }

}
