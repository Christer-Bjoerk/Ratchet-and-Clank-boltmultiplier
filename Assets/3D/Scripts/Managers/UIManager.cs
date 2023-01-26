using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : PersistentSingleton<UIManager> 
{
    [SerializeField] private TMP_Text boltText;

    private void Start()
    {
        boltText.text = BoltTracker.Instance.currentBolts.ToString();
    }

    private void Update()
    {
        // TODO: ToString allocates too much in update
        // Event based
        boltText.text = BoltTracker.Instance.currentBolts.ToString();
    }
}
