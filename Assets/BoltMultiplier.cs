using UnityEngine;
using TMPro;

public class BoltMultiplier : MonoBehaviour
{
    [Header("Multiplier")]
    [SerializeField] private float multiplier = 1;
    [SerializeField] private int maxMultiplier = 20;

    [Header("Texts")]
    [SerializeField] private TMP_Text textBoltMultiplier;
    [SerializeField] private TMP_Text textDefeatTracker;

    private int defeatTracker;

    public void IncreaseDefeatTracker()
    {
        defeatTracker++;
        textDefeatTracker.text = "Enemies Defeated " + defeatTracker.ToString();

        BoltMultiply();
    }

    public void BoltMultiply()
    {
        float equation = (2f * Mathf.Sqrt(defeatTracker));

        multiplier = (int)(equation);

        // Like Ratchet & Clank, the multipler will stop at 20
        // But can be changed to your liking
        if (multiplier >= maxMultiplier)
        {
            multiplier = maxMultiplier;
        }

        textBoltMultiplier.text = "Multiplier " + multiplier.ToString() +"x";
    }

    public void ResetMultiplier()
    {
        multiplier = 1;
        defeatTracker = 0;
        textBoltMultiplier.text = "Multiplier " + multiplier.ToString();
        textDefeatTracker.text = "Enemies Defeated " + defeatTracker.ToString();
    }
}