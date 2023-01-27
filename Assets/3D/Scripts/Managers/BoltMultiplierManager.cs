using UnityEngine;

public class BoltMultiplierManager : PersistentSingleton<BoltMultiplierManager>
{
    [Header("Multiplier")]
    [SerializeField] private int maxMultiplier = 20;

    [Header("Variables")]
    [SerializeField] private IntVariable multiplier;

    [SerializeField] private IntVariable enemyDefeated;

    /// <summary>
    /// Update the multiplier based on
    /// how many enemies are defeated without being hit
    /// </summary>
    public void UpdateBoltMultiplier()
    {
        // +=
        enemyDefeated.ApplyChange(1);
        float equation = (2f * Mathf.Sqrt(enemyDefeated.Value));
        // =
        multiplier.SetValue((int)equation);

        // Like Ratchet & Clank, the multipler will stop at 20
        // But can be changed to your liking
        if (multiplier.Value >= maxMultiplier)
            multiplier.Value = maxMultiplier;
    }

    public void ResetMultiplier()
    {
        multiplier.SetValue(1);
        enemyDefeated.SetValue(0);
    }
}