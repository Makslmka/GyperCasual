using System.Runtime.InteropServices;
using UnityEngine;

public class GameReadyAPI : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendGameReadyApi();

    private void OnEnable()
    {
        //Invoke("SendGameReadyApi", 5f);
    }

    public void GameReady()
    { 
        SendGameReadyApi();
    }
}
