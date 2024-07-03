using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int _coinCost;

    public void PickUpCoin()
    {
        EventBus.CoinPickUp(_coinCost);
    }
}
