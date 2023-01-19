using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCollectibles : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pickupDistance = 0.1f;
    [SerializeField] private Transform player;

    private List<GameObject> collectibles = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            collectibles.Add(other.gameObject);
        }
    }

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
                Destroy(collectibles[i].gameObject);
                collectibles.Remove(collectibles[i]);
            }
        }
    }
}
