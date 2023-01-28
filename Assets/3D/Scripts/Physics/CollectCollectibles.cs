using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReturnObject))]
public class CollectCollectibles : MonoBehaviour
{
    [Header("Item Settings")]
    [SerializeField] private float speed = 5f;

    [SerializeField] private float pickupDistance = 0.1f;
    [SerializeField] private Transform player;

    private List<GameObject> collectibles = new List<GameObject>();

    private void Update()
    {
        PickupCollectibles();
    }

    private void PickupCollectibles()
    {
        for (int i = 0; i < collectibles.Count; i++)
        {
            collectibles[i].transform.position = Vector3.MoveTowards(collectibles[i].transform.position, player.position, speed * Time.deltaTime);

            if (Vector3.Distance(collectibles[i].transform.position, player.position) <= pickupDistance)
            {
                // Object pool
                collectibles[i].gameObject.SetActive(false);
                collectibles.Remove(collectibles[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
            collectibles.Add(other.gameObject);
    }
}