using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject bulletDecal;
    [SerializeField] private float speed = 5f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private float timeToDestroy = 3f;

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        BulletMovement();
    }

    private void BulletMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {
            // Object Pool
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        GameObject.Instantiate(bulletDecal, contact.point, Quaternion.LookRotation(contact.normal));
        
        // TODO - Object Pool
        Destroy(gameObject);
    }
}