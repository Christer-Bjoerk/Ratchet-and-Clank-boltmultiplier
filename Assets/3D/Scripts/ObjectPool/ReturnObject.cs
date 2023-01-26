using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{
    private ObjectPoolManager poolManager;

    private void OnDisable()
    {
        if (poolManager != null)
            poolManager.ReturnGameObject(this.gameObject);
    }

    private void Start()
    {
        poolManager = FindObjectOfType<ObjectPoolManager>();
    }

}
