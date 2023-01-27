using TMPro;
using UnityEngine;

public class UIManager : PersistentSingleton<UIManager>
{
    [Header("Texts")]
    [SerializeField] private TMP_Text boltText;

    [SerializeField] private TMP_Text textBoltMultiplier;
    [SerializeField] private string text;

    [Header("Variables")]
    [SerializeField] private IntVariable boltValue;

    [SerializeField] private IntVariable multiplier;
    [SerializeField] private IntVariable collectedBolts;

    private void Start()
    {
        boltText.text = collectedBolts.Value.ToString();
        textBoltMultiplier.text = multiplier.Value.ToString() + text;
    }

    public void UpdateBoltMultiplierText()
    {
        textBoltMultiplier.text = multiplier.Value.ToString() + text;
    }

    public void UpdateBoltText()
    {
        boltText.text = collectedBolts.Value.ToString();
    }
}