using UnityEngine;

public class BoltTracker : PersistentSingleton<BoltTracker>
{
    [HideInInspector]
    public int currentBolts { get; private set; } = 0;

    public void AddBolts(int value)
    {
        currentBolts += value * BoltMultiplierManager.Instance.multiplier;
    }
}