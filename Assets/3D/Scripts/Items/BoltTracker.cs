using UnityEngine;

public class BoltTracker : PersistentSingleton<BoltTracker>
{
    [SerializeField] private IntVariable boltValue;
    [SerializeField] private IntVariable multiplier;
    [SerializeField] private IntVariable collectedBolts;

    public void AddBolts()
    {
        collectedBolts.ApplyChange(boltValue.Value * multiplier.Value);
    }
}