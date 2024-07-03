using System;

public class EventBus
{
    public static event Func<Player> ObjectSpawned;
    public static event Func<Language> RequestLanguage;
    public static event Action LanguageChanged;
    public static event Action TimelinesStarting;

    public static event Action PlayerStartRunning;
    public static event Action PlayerStopRunning;
    public static event Action PlayerAttacking;

    public static event Action<int> CoinPickedUp;
    public static event Action<int> CoinsChanged;
    public static event Action CoinsSpended;
    public static event Action<int> GatePlayerEntered;
    public static event Action<int, int> ProgressLevelChanged;
    public static event Action<int> LevelSeted;

    public static Player GetPlayer()
    {
        return ObjectSpawned?.Invoke();
    }

    public static Language GetLanguage()
    {
        return RequestLanguage?.Invoke();
    }

    public static void LanguageChange()
    {
        LanguageChanged?.Invoke();
    }

    public static void StartTimelines()
    {
        TimelinesStarting?.Invoke();
    }

    public static void PlayerStartRun()
    {
        PlayerStartRunning?.Invoke();
    }

    public static void PlayerStopRun()
    {
        PlayerStopRunning?.Invoke();
    }

    public static void PlayerAttack()
    {
        PlayerAttacking?.Invoke();
    }

    public static void CoinPickUp(int count)
    {
        CoinPickedUp?.Invoke(count);
    }

    public static void SendCoins(int count)
    { 
        CoinsChanged?.Invoke(count);
    }

    public static void CoinsSpending()
    {
        CoinsSpended?.Invoke();
    }

    public static void GatePlayerEnter(int count)
    {
        GatePlayerEntered?.Invoke(count);
    }

    public static void SendProgressLevel(int current, int max)
    {
        ProgressLevelChanged?.Invoke(current, max);
    }

    public static void SendLevel(int vale)
    {
        LevelSeted?.Invoke(vale);
    }
}
