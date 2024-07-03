using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;

    private void StartTimeLine()
    { 
        _playableDirector.Play();
    }

    private void OnEnable()
    {
        EventBus.TimelinesStarting += StartTimeLine;
    }

    private void OnDisable()
    {
        EventBus.TimelinesStarting -= StartTimeLine;
    }
}
