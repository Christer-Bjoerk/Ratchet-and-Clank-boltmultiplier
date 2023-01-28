using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ReturnObject))]
public class BulletController : MonoBehaviour
{
    [Header("Bullet Configuration")]
    [SerializeField] private float speed = 5f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private float timeToDeactivate = 3f;

    private void OnEnable()
    {
        StartCoroutine(DeactiveBullet());
    }

    private void Update()
    {
        BulletMovement();
    }

    /// <summary>
    /// Bullet move in the direction of
    /// the raycasted target
    /// </summary>
    private void BulletMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        ReuseBullet();
    }


    private void ReuseBullet()
    {
        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
            // Return to the object pool
            this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }

    private IEnumerator DeactiveBullet()
    {
        yield return new WaitForSeconds(timeToDeactivate);

        this.gameObject.SetActive(false);

        yield return null;
    }
}