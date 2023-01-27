using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolts : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;

    [SerializeField] private IntVariable boltValue;
    [SerializeField] private IntReference boltReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            gameEvent.TriggerEvent();
        }
    }
}
