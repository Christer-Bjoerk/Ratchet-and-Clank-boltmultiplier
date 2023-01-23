using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour
{
    [SerializeField] private int boltValue = 2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            BoltTracker.Instance.AddBolts(boltValue);
        }
    }
}
