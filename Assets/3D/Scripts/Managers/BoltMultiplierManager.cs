using TMPro;
using UnityEngine;

public class BoltMultiplierManager : PersistentSingleton<BoltMultiplierManager>
{
    public int multiplier { get; private set; } = 1;

    [Header("Multiplier")]
    [SerializeField] private int maxMultiplier = 20;

    [Header("Texts")]
    [SerializeField] private TMP_Text textBoltMultiplier;
    [SerializeField] private string text;

    [HideInInspector]
    public int defeatTracker { get; private set; } = 0;

    private void Start()
    {
        // Move to the UI Manager
        textBoltMultiplier.text = "1x";
    }

    public void BoltMultiply()
    {
        defeatTracker++;

        float equation = (2f * Mathf.Sqrt(defeatTracker));

        multiplier = (int)(equation);

        // Like Ratchet & Clank, the multipler will stop at 20
        // But can be changed to your liking
        if (multiplier >= maxMultiplier)
        {
            multiplier = maxMultiplier;
        }

        // Move to the UI Manager
        textBoltMultiplier.text = multiplier.ToString() + text;
    }

    public void ResetMultiplier()
    {
        multiplier = 1;
        defeatTracker = 0;

        // Move to the UI Manager
        textBoltMultiplier.text = multiplier.ToString() + text;
    }
}