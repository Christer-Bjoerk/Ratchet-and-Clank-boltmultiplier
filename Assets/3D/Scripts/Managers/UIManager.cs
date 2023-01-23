using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : PersistentSingleton<UIManager> 
{
    [SerializeField] private TMP_Text BoltText;


    private void Start()
    {
        BoltText.text = BoltTracker.Instance.currentBolts.ToString();
    }

    private void Update()
    {
        BoltText.text = BoltTracker.Instance.currentBolts.ToString();
    }
}
