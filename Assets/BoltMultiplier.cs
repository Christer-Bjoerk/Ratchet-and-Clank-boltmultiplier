using UnityEngine;
using TMPro;

public class BoltMultiplier : MonoBehaviour
{
    [SerializeField] private int multiplier = 1;
    [SerializeField] private int maxMultiplier = 20;
    [SerializeField] private TMP_Text textBoltMultiplier;

    [SerializeField] private int killCounter;

    public void IncreaseKillCounter()
    {
        killCounter++;
        BoltMultiply();
    }

    public void BoltMultiply()
    {

        multiplier = (int)(2 * Mathf.Sqrt(killCounter));

        // Like Ratchet & Clank, the multipler will stop at 20
        // But can be changed to your liking
        if (multiplier >= maxMultiplier || killCounter > 100)
        {
            multiplier = 20;
        }

        textBoltMultiplier.text = "Multiplier " + multiplier.ToString();
    }

    public void Reset()
    {
        multiplier = 1;
        killCounter = 0;
        textBoltMultiplier.text = "Multiplier " + multiplier.ToString();
    }
}