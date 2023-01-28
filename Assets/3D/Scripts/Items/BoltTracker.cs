using UnityEngine;

public class BoltTracker : PersistentSingleton<BoltTracker>
{
    [Header("Variables")]
    [SerializeField] private IntVariable boltValue;
    [SerializeField] private IntVariable multiplier;
    [SerializeField] private IntVariable collectedBolts;

    public void AddBolts()
    {
        // Total bolts collected
        collectedBolts.ApplyChange(boltValue.Value * multiplier.Value);
    }
}