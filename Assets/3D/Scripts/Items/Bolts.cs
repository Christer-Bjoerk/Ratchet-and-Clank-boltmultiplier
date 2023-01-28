using UnityEngine;

public class Bolts : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent updateBoltsEvent;

    [Header("Variables")]
    [SerializeField] private IntVariable boltValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
            // Add bolts
            updateBoltsEvent.TriggerEvent();
    }
}