using UnityEngine;

public class ReturnObject : MonoBehaviour
{
    private ObjectPoolManager poolManager;

    private void Start()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

    private void OnDisable()
    {
        if (poolManager != null)
            poolManager.ReturnGameObject(this.gameObject);
    }
}