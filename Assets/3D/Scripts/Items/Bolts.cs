using UnityEngine;

public class Bolts : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private GameEvent updateBoltsEvent;

    [Header("Variables")]
    [SerializeField] private IntVariable boltValue;

    [SerializeField] private IntReference boltReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            updateBoltsEvent.TriggerEvent();
        }
    }
}