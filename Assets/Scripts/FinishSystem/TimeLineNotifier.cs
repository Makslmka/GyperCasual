using UnityEngine;

public class TimeLineNotifier : MonoBehaviour
{
    public void NotifyTimeLine()
    {
        EventBus.StartTimelines();
    }
}
