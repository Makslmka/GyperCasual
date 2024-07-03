using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private GateRandomNumber _gateRandomNumber;
    [SerializeField] private GateColorChanger _gateSpriteColor;
    [SerializeField] private GateNumberText _gateNumberText;
    [SerializeField] private GateSoundSpawner _gateSoundSpawner;

    private int _number;

    private void Start()
    {
        _number = _gateRandomNumber.GetNumber();

        _gateNumberText.SetText(_number);

        _gateSpriteColor.SetColor(_number);

        _gateSoundSpawner.SetAudioClip(_number);
    }

    public void PlayerEnter()
    {
        EventBus.GatePlayerEnter(_number);
    }
}
