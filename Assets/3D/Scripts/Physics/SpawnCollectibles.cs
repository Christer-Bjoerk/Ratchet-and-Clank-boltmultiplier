using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    [SerializeField] private GameObject collectiblePrefab;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(collectiblePrefab, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
