using UnityEngine;

public class GateRandomNumber : MonoBehaviour
{
    [SerializeField] private int[] _numbers;

    private int _randomNumber;

    public int GetNumber()
    { 
        _randomNumber = Random.Range(0, _numbers.Length);

        return _numbers[_randomNumber];
    }
}
