using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Doesn't destroy any new instances but overrides them instead
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// The classic Singleton pattern where any new instance will be destroyed
/// leaving the original intact.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> : BaseSingleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        base.Awake();
    }
}

/// <summary>
/// Will persist across scenes
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PersistentSingleton<T> : BaseSingleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
